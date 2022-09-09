namespace AdminAPI.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string NumeroLei { get; set; }
        public string Descricao { get; set; }
        public Politico Politico { get; set; }

        public Projeto()
        {
        }

        public Projeto(string numeroLei, string descricao, Politico politico)
        {
            NumeroLei = numeroLei;
            Descricao = descricao;
            Politico = politico;
        }
    }
}