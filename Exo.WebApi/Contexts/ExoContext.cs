using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext(DbContextOptions<ExoContext> options) : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

