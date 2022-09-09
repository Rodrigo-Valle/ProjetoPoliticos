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
    public class ProjetoService : IProjetoService
    {
        private HATEOAS.HATEOAS HATEOAS;
        private readonly AppDbContext _database;
        public ProjetoService(AppDbContext database)
        {
            _database = database;
            HATEOAS = new HATEOAS.HATEOAS("localhost:5002/api/v1/projeto");    
            HATEOAS.AddAction("DELETE_PROJETO", "DELETE");
            HATEOAS.AddAction("EDIT_PROJETO", "PUT"); 
        }

        public Task Criar(ProjetoInputModel dto)
        {
            if (_database.Projetos.Any(x => x.NumeroLei == dto.NumeroLei))
            {
                throw new ObjetoJaCadastradoException("Ja existe projeto cadastrado com esse numero");
            }

            var politico = _database.Politicos.FirstOrDefault(x => x.Id == dto.Politico);
            
            if(politico == null){
                throw new ObjetoNaoLocalizadoException("Politico não localizado");
            }
            
            Projeto p = new Projeto{
                NumeroLei = dto.NumeroLei,
                Descricao = dto.Descricao,
                Politico = politico
            };
            _database.Projetos.Add(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Editar(int id, ProjetoInputModel dto)
        {
            var politico = _database.Politicos.FirstOrDefault(x => x.Id == dto.Politico);
            if(politico == null){
                throw new ObjetoNaoLocalizadoException("Politico não localizado");
            }
            
            var projeto = _database.Projetos.FirstOrDefault(x => x.Id == id);
            if(projeto == null){
                throw new ObjetoNaoLocalizadoException("Processo nao encontrado");
            }
            projeto.NumeroLei = dto.NumeroLei;
            projeto.Descricao = dto.Descricao;
            projeto.Politico =  politico;
            _database.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<ProjetoViewModel>> Listar()
        {
            var lista = _database.Projetos.Include(x => x.Politico).Include(x => x.Politico.Partido).Select(x => new ProjetoViewModel{
                Id = x.Id,
                NumeroLei = x.NumeroLei,
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

        public Task<ProjetoViewModel> Obter(int id)
        {
            var projeto = _database.Projetos.Include(x => x.Politico).Include(x => x.Politico.Partido).Select(x => new ProjetoViewModel{
                Id = x.Id,
                NumeroLei = x.NumeroLei,
                Descricao = x.Descricao,
                PoliticoNome = x.Politico.Nome,
                PoliticoPartido = x.Politico.Partido.Nome
            }).FirstOrDefault(x => x.Id == id);
            if (projeto == null)
            {
                throw new ObjetoNaoLocalizadoException("projeto nao encontrado");
            }
            projeto.Links = HATEOAS.GetActions(projeto.Id.ToString());
            return Task.FromResult(projeto);
        }

        public Task Remover(int id)
        {
            var p = _database.Projetos.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                throw new ObjetoNaoLocalizadoException("Projeto nao encontrado");
            }
            _database.Remove(p);
            _database.SaveChanges();
            return Task.CompletedTask;
        }
    }
}