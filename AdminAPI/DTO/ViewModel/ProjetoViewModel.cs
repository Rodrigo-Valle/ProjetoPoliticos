using AdminAPI.HATEOAS;

namespace AdminAPI.DTO.ViewModel
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public string NumeroLei { get; set; }
        public string Descricao { get; set; }
        public string PoliticoNome { get; set; }
        public string PoliticoPartido { get; set; }
        public Link[] Links { get; set; }
    }
}