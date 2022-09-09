using System.Collections.Generic;

namespace AdminAPI.DTO.ViewModel
{
    public class PoliticoTratadoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public string Foto { get; set; }
        public string Cargo { get; set; }
        public bool Lideranca { get; set; }
        public IEnumerable<ProcessoResumidoViewModel> Processos { get; set; }
        public IEnumerable<ProjetoResumidoViewModel> Projetos { get; set; }
    }
}