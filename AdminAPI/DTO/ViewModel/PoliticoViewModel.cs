using AdminAPI.HATEOAS;

namespace AdminAPI.DTO.ViewModel
{
    public class PoliticoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Partido { get; set; }
        public string Foto { get; set; }
        public string Cargo { get; set; }
        public bool Lideranca { get; set; }
        public Link[] Links { get; set; }
    }
}