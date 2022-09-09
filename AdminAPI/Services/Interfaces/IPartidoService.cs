using System.Collections.Generic;
using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;
using AdminAPI.DTO.ViewModel;

namespace AdminAPI.Services
{
    public interface IPartidoService
    {
        Task<List<PartidoViewModel>> Listar();
        Task<PartidoViewModel> Obter(int id);
        Task Criar(PartidoInputModel dto);
        Task Editar(int id, PartidoInputModel dto);
        Task Remover(int id);
    }
}