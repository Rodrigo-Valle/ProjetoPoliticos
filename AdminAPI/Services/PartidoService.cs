using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Data;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;
using AdminAPI.Exceptions;
using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Services
{
    public class PartidoService : IPartidoService
    {
        private HATEOAS.HATEOAS HATEOAS;
        private readonly AppDbContext _database;
        public PartidoService(AppDbContext database)
        {
            _database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5002/api/v1/Partido");
            HATEOAS.AddAction("DELETE_PARTIDO", "DELETE");
            HATEOAS.AddAction("EDIT_PARTIDO", "PUT");
        }

        public Task Criar(PartidoInputModel dto)
        {
            if (_database.Partidos.Any(x => x.Nome == dto.Nome) || _database.Partidos.Any(x => x.Sigla == dto.Sigla))
            {
                throw new ObjetoJaCadastradoException("Ja existe partido com esse nome ou sigla");
            }
            Partido p = new Partido
            {
                Nome = dto.Nome,
                Sigla = dto.Sigla
            };
            _database.Partidos.Add(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Editar(int id, PartidoInputModel dto)
        {
            var partido = _database.Partidos.FirstOrDefault(x => x.Id == id);
            if (partido == null)
            {
                throw new ObjetoNaoLocalizadoException("Partido não encontrado");
            }
            partido.Nome = dto.Nome != null ? dto.Nome : partido.Nome;
            partido.Sigla = dto.Sigla;
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<PartidoViewModel>> Listar()
        {
            var lista = _database.Partidos.Select(x => new PartidoViewModel
            {
                Id = x.Id,
                Sigla = x.Sigla,
                Nome = x.Nome
            }).ToList();
            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("Não há partidos cadastrados");
            }
            foreach (var p in lista)
            {
                p.Links = HATEOAS.GetActions(p.Id.ToString());
            }
            return Task.FromResult(lista);
        }

        public Task<PartidoViewModel> Obter(int id)
        {
            var partido = _database.Partidos.Select(x => new PartidoViewModel
            {
                Id = x.Id,
                Sigla = x.Sigla,
                Nome = x.Nome
            }).FirstOrDefault(x => x.Id == id);
            if (partido == null)
            {
                throw new ObjetoNaoLocalizadoException("Partido não encontrado");
            }
            partido.Links = HATEOAS.GetActions(partido.Id.ToString());
            return Task.FromResult(partido);
        }

        public Task Remover(int id)
        {
            var p = _database.Partidos.Include(x => x.Politicos).FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new ObjetoNaoLocalizadoException("Partido não encontrado");
            }
            if (p.Politicos.Any())
            {
                throw new PoliticoComProjetosOuProcessoExcpetion("não é possivel remover Partido que possui politicos");
            }
            _database.Remove(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }
    }
}