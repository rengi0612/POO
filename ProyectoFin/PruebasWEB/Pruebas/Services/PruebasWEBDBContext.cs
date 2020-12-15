using Microsoft.EntityFrameworkCore;
using Pruebas.Models;

namespace Pruebas.Services
{
    public class PruebasWEBDBContext : DbContext
    {
        public PruebasWEBDBContext(DbContextOptions<PruebasWEBDBContext> options)
                    : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
    }
}
