using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeAlimentos.Models;

namespace ProjetoDoacaoDeAlimentos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoDoacaoDeAlimentos.Models.Alimento> Alimento { get; set; }
        public DbSet<ProjetoDoacaoDeAlimentos.Models.Distribuidor> Distribuidor { get; set; }
        public DbSet<ProjetoDoacaoDeAlimentos.Models.Doacao> Doacao { get; set; }
        public DbSet<ProjetoDoacaoDeAlimentos.Models.Doador> Doador { get; set; }
    }
}