using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Modelos;

namespace PeliculasAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        // Aqui pasar todas las entidades (Modelos)
        public DbSet<Categoria> Categoria { get; set; }
    }
}
