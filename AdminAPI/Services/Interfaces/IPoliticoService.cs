using System.Collections.Generic;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;

namespace AdminAPI.Services
{
    public interface IPoliticoService
    {
        Task<List<PoliticoViewModel>> Listar();
        Task<PoliticoViewModel> Obter(int id);
        Task Criar(PoliticoInputModel dto);
        Task Editar(int id, PoliticoInputModel dto);
        Task Remover(int id);
        Task AlterarLideranca(int id);
    }
}