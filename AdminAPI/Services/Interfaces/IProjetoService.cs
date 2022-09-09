using System.Collections.Generic;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;

namespace AdminAPI.Services
{
    public interface IProjetoService
    {
        Task<List<ProjetoViewModel>> Listar();
        Task<ProjetoViewModel> Obter(int id);
        Task Criar(ProjetoInputModel dto);
        Task Editar(int id, ProjetoInputModel dto);
        Task Remover(int id);
    }
}