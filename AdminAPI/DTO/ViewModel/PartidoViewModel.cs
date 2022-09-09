using AdminAPI.HATEOAS;

namespace AdminAPI.DTO.ViewModel
{
    public class PartidoViewModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Link[] Links { get; set; }
    }
}