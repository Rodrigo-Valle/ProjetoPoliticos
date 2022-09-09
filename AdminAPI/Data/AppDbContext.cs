using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Politico> Politicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}