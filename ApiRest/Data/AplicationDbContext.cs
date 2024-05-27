using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
