using System.Collections.Generic;
using UserAPI.DTO;

namespace UserApi.DTO
{
    public class PoliticoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public string Foto { get; set; }
        public string Cargo { get; set; }
        public bool Lideranca { get; set; }
        public IEnumerable<ProcessoViewModel> Processos { get; set; }
        public IEnumerable<ProjetoViewModel> Projetos { get; set; }
    }
}