using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Data;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;
using AdminAPI.Exceptions;
using AdminAPI.Models;
using AdminAPI.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Services
{
    public class PoliticoService : IPoliticoService
    {
        private HATEOAS.HATEOAS HATEOAS;
        private readonly AppDbContext _database;
        public PoliticoService(AppDbContext database)
        {
            _database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5002/api/v1/Politico");
            HATEOAS.AddAction("DELETE_POLITICO", "DELETE");
            HATEOAS.AddAction("EDIT_POLITICO", "PUT");
        }

        public Task Criar(PoliticoInputModel dto)
        {
            if (_database.Politicos.Any(x => x.Nome == dto.Nome) || _database.Politicos.Any(x => x.CPF == dto.CPF))
            {
                throw new ObjetoJaCadastradoException("Já existe politico cadastrado com esse CPF ou Nome");
            }
            var partido = _database.Partidos.FirstOrDefault(x => x.Id == dto.Partido);
            if (partido == null)
            {
                throw new ObjetoNaoLocalizadoException("Partido não localizado");
            }

            Politico p = new Politico
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Foto = dto.Foto,
                Partido = partido,
                Cargo = Enum.Parse<Cargo>(dto.Cargo)
            };
            _database.Politicos.Add(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Editar(int id, PoliticoInputModel dto)
        {
            var partido = _database.Partidos.FirstOrDefault(x => x.Id == dto.Partido);
            if (partido == null)
            {
                throw new ObjetoNaoLocalizadoException("Partido não localizado");
            }

            var p = _database.Politicos.FirstOrDefault(x => x.Id == id);

            if (p == null)
            {
                throw new ObjetoNaoLocalizadoException("Politico não localizado");
            }

            p.Nome = dto.Nome;
            p.CPF = dto.CPF;
            p.Endereco = dto.Endereco;
            p.Telefone = dto.Telefone;
            p.Foto = dto.Foto;
            p.Partido = partido;
            p.Cargo = Enum.Parse<Cargo>(dto.Cargo);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<PoliticoViewModel>> Listar()
        {
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Select(x => new PoliticoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                CPF = x.CPF,
                Endereco = x.Endereco,
                Telefone = x.Telefone,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
            }).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("Não há politicos cadastrados");
            }

            foreach (var p in lista)
            {
                p.Links = HATEOAS.GetActions(p.Id.ToString());
            }
            return Task.FromResult(lista);
        }

        public Task<PoliticoViewModel> Obter(int id)
        {
            var politico = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Select(x => new PoliticoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                CPF = x.CPF,
                Endereco = x.Endereco,
                Telefone = x.Telefone,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
            }).FirstOrDefault(x => x.Id == id);

            if (politico == null)
            {
                throw new ObjetoNaoLocalizadoException("Politico não encontrado");
            }

            politico.Links = HATEOAS.GetActions(politico.Id.ToString());
            return Task.FromResult(politico);
        }

        public Task Remover(int id)
        {
            var p = _database.Politicos.Include(x => x.Projetos).Include(x => x.Processos).FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new ObjetoNaoLocalizadoException("politico nao encontrado");
            }
            if (p.Processos.Any() || p.Projetos.Any())
            {
                throw new PoliticoComProjetosOuProcessoExcpetion("politico possui projeto ou processo cadastrado, delete-os antes");
            }
            _database.Remove(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AlterarLideranca(int id)
        {
            var pol = _database.Politicos.FirstOrDefault(x => x.Id == id);
            if (pol == null)
            {
                throw new ObjetoNaoLocalizadoException("politico nao encontrado");
            }
            if (pol.Cargo == Cargo.deputado)
            {
                if (pol.Lider == false)
                    pol.Lider = true;

                else
                    pol.Lider = false;

                _database.Politicos.Update(pol);
                _database.SaveChanges();
                return Task.CompletedTask;

            }
            else
            {
                throw new LiderancaException("Apenas Deputados podem assumir liderança");
            }
        }
    }
}