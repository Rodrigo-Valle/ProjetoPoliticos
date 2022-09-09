using System.Collections.Generic;

namespace UserAPI.DTO
{
    public class PoliticoProjetosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public int QtdProjetos { get; set; }
        public IEnumerable<ProjetoResumidoViewModel> Projetos { get; set; }
    }
}