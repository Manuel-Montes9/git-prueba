using CursoRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CursoRazor.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
    }
}
