using System.Collections.Generic;
using AdminAPI.Models.Enum;

namespace AdminAPI.Models
{
    public class Politico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public Partido Partido { get; set; }
        public string Foto { get; set; }
        public Cargo Cargo { get; set; }
        public List<Processo> Processos { get; set; }
        public List<Projeto> Projetos { get; set; }
        public bool Lider { get; set; }

        public Politico()
        {
        }

        public Politico(string nome, string cpf, string endereco, string telefone, Partido partido, string foto,
        Cargo cargo, bool lider)
        {
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Partido = partido;
            Foto = foto;
            Cargo = cargo;
            Lider = lider;
        }
    }
}