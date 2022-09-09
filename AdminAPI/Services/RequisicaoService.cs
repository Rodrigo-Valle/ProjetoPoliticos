using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Data;
using AdminAPI.DTO.ViewModel;
using AdminAPI.Exceptions;
using AdminAPI.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Services
{
    public class RequisicaoService : IRequisicaoService
    {
        private readonly AppDbContext _database;

        public RequisicaoService(AppDbContext database)
        {
            _database = database;
        }

        public Task<List<PoliticoTratadoViewModel>> Listar()
        {
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Select(x => new PoliticoTratadoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                }),
                Processos = x.Processos.Select(y => new ProcessoResumidoViewModel
                {
                    Id = y.Id,
                    Numero = y.Numero,
                    Descricao = y.Descricao
                })
            }).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }
            return Task.FromResult(lista);
        }

        public Task<PoliticoTratadoViewModel> Obter(int id)
        {
            var politico = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Select(x => new PoliticoTratadoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                }),
                Processos = x.Processos.Select(y => new ProcessoResumidoViewModel
                {
                    Id = y.Id,
                    Numero = y.Numero,
                    Descricao = y.Descricao
                })
            }).FirstOrDefault(x => x.Id == id);

            if (politico == null)
            {
                throw new ObjetoNaoLocalizadoException("Politico nao encontrado");
            }
            return Task.FromResult(politico);
        }

        public Task<List<PoliticoTratadoViewModel>> ListarPorCargoAsc(string cargo)
        {
            var c = Enum.Parse<Cargo>(cargo.ToLower());
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Where(x => x.Cargo == c).Select(x => new PoliticoTratadoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                }),
                Processos = x.Processos.Select(y => new ProcessoResumidoViewModel
                {
                    Id = y.Id,
                    Numero = y.Numero,
                    Descricao = y.Descricao
                })
            }).OrderBy(x => x.Nome).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }
            return Task.FromResult(lista);
        }


        public Task<List<PoliticoTratadoViewModel>> ListarPorCargoDesc(string cargo)
        {
            var c = Enum.Parse<Cargo>(cargo.ToLower());
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Processos).Include(x => x.Projetos).Where(x => x.Cargo == c).Select(x => new PoliticoTratadoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Foto = x.Foto,
                Partido = x.Partido.Nome,
                Cargo = x.Cargo.ToString(),
                Lideranca = x.Lider,
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                }),
                Processos = x.Processos.Select(y => new ProcessoResumidoViewModel
                {
                    Id = y.Id,
                    Numero = y.Numero,
                    Descricao = y.Descricao
                })
            }).OrderByDescending(x => x.Nome).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }
            return Task.FromResult(lista);
        }

        public Task<List<PoliticoProjetosViewModel>> ListarPorQtdDeProjetos()
        {
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Projetos).Select(x => new PoliticoProjetosViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Partido = x.Partido.Nome,
                QtdProjetos = x.Projetos.Count(),
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                })
            }).OrderByDescending(x => x.QtdProjetos).ToList();

            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }
            return Task.FromResult(lista);
        }

        public Task<List<PoliticoProjetosViewModel>> FiltrarPorQtdDeProjetos(int numero)
        {
            var lista = _database.Politicos.Include(x => x.Partido).Include(x => x.Projetos).Where(x => x.Projetos.Count() == numero).Select(x => new PoliticoProjetosViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Partido = x.Partido.Nome,
                QtdProjetos = x.Projetos.Count(),
                Projetos = x.Projetos.Select(y => new ProjetoResumidoViewModel
                {
                    Id = y.Id,
                    NumeroLei = y.NumeroLei,
                    Descricao = y.Descricao
                })
            }).ToList();
            
            if (lista.Count() == 0)
            {
                throw new ObjetoNaoLocalizadoException("");
            }
            return Task.FromResult(lista);
        }
    }
}