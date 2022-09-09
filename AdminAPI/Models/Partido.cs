using System.Collections.Generic;

namespace AdminAPI.Models
{
    public class Partido
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public List<Politico> Politicos { get; set; }

        public Partido()
        {
        }

        public Partido(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }
    }
}