using AdminAPI.HATEOAS;

namespace AdminAPI.DTO.ViewModel
{
    public class ProcessoViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public string PoliticoNome { get; set; }
        public string PoliticoPartido { get; set; }
        public Link[] Links { get; set; }
    }
}