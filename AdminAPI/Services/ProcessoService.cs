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
    public class ProcessoService : IProcessoService
    {
        private HATEOAS.HATEOAS HATEOAS;
        private readonly AppDbContext _database;
        public ProcessoService(AppDbContext database)
        {
            _database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5002/api/v1/processo");
            HATEOAS.AddAction("DELETE_PROCESSO", "DELETE");
            HATEOAS.AddAction("EDIT_PROCESSO", "PUT");
        }

        public Task Criar(ProcessoInputModel dto)
        {
            if (_database.Processos.Any(x => x.Numero == dto.Numero))
            {
                throw new ObjetoJaCadastradoException("processo ja cadastrado");
            }

            var politico = _database.Politicos.FirstOrDefault(x => x.Id == dto.Politico);

            if (politico == null)
            {
                throw new ObjetoNaoLocalizadoException("Politico não encontrado");
            }

            if (politico.Cargo == Cargo.vereador || politico.Cargo == Cargo.deputado || politico.Cargo == Cargo.governador)
            {
                Processo p = new Processo
                {
                    Numero = dto.Numero,
                    Descricao = dto.Descricao,
                    Politico = politico
                };

                _database.Processos.Add(p);
                _database.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new ProcessoNaoPermitidoException("Apenas Vereadores, Deputados e Governadores podem ter processos");
            }
        }


        public Task Editar(int id, ProcessoInputModel dto)
        {
            var politico = _database.Politicos.FirstOrDefault(x => x.Id == dto.Politico);

            if (politico == null)
            {
                throw new ObjetoNaoLocalizadoException("Politico não encontrado");
            }

            if (politico.Cargo == Cargo.vereador || politico.Cargo == Cargo.deputado || politico.Cargo == Cargo.governador)
            {
                var processo = _database.Processos.FirstOrDefault(x => x.Id == id);

                if (processo == null)
                {
                    throw new ObjetoNaoLocalizadoException("Processo não encontrado");
                }

                processo.Numero = dto.Numero;
                processo.Descricao = dto.Descricao;
                processo.Politico = politico;
                _database.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new ProcessoNaoPermitidoException("Apenas Vereadores, Deputados e Governadores podem ter processos");
            }
        }

        public Task<List<ProcessoViewModel>> Listar()
        {
            var lista = _database.Processos.Include(x => x.Politico).Include(x => x.Politico.Partido).Select(x => new ProcessoViewModel
            {
                Id = x.Id,
                Numero = x.Numero,
                Descricao = x.Descricao,
                PoliticoNome = x.Politico.Nome,
                PoliticoPartido = x.Politico.Partido.Nome
            }).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }

            foreach (var p in lista)
            {
                p.Links = HATEOAS.GetActions(p.Id.ToString());
            }

            return Task.FromResult(lista);
        }

        public Task<ProcessoViewModel> Obter(int id)
        {
            var processo = _database.Processos.Include(x => x.Politico).Include(x => x.Politico.Partido).Select(x => new ProcessoViewModel
            {
                Id = x.Id,
                Numero = x.Numero,
                Descricao = x.Descricao,
                PoliticoNome = x.Politico.Nome,
                PoliticoPartido = x.Politico.Partido.Nome
            }).FirstOrDefault(x => x.Id == id);

            if (processo == null)
            {
                throw new ObjetoNaoLocalizadoException("Processo nao encontrado");
            }
            
            processo.Links = HATEOAS.GetActions(processo.Id.ToString());
            return Task.FromResult(processo);
        }

        public Task Remover(int id)
        {
            var p = _database.Processos.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new ObjetoNaoLocalizadoException("processo nao encontrado");
            }
            _database.Remove(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }
    }
}