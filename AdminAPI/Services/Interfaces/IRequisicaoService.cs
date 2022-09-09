using System.Collections.Generic;
using System.Threading.Tasks;
using AdminAPI.DTO.ViewModel;

namespace AdminAPI.Services
{
    public interface IRequisicaoService
    {
        Task<List<PoliticoTratadoViewModel>> Listar();
        Task<PoliticoTratadoViewModel> Obter(int id);
        Task<List<PoliticoTratadoViewModel>> ListarPorCargoAsc(string cargo);
        Task<List<PoliticoTratadoViewModel>> ListarPorCargoDesc(string cargo);
        Task<List<PoliticoProjetosViewModel>> ListarPorQtdDeProjetos();
        Task<List<PoliticoProjetosViewModel>> FiltrarPorQtdDeProjetos(int numero);
    }
}