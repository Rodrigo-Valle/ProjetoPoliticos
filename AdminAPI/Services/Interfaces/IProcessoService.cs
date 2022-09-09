using System.Collections.Generic;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;

namespace AdminAPI.Services
{
    public interface IProcessoService
    {
        Task<List<ProcessoViewModel>> Listar();
        Task<ProcessoViewModel> Obter(int id);
        Task Criar(ProcessoInputModel dto);
        Task Editar(int id, ProcessoInputModel dto);
        Task Remover(int id);
    }
}