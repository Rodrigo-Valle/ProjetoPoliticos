namespace AdminAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }

        public Usuario()
        {
        }

        public Usuario(string usuario, string senha, bool admin)
        {
            User = usuario;
            Senha = senha;
            Admin = admin;
        }
    }
}