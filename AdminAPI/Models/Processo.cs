namespace AdminAPI.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public Politico Politico { get; set; }

        public Processo()
        {
        }

        public Processo(string numero, string descricao, Politico politico)
        {
            Numero = numero;
            Descricao = descricao;
            Politico = politico;
        }
    }
}