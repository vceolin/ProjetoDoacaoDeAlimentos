using ProjetoDoacaoDeAlimentos.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoDoacaoDeAlimentos.DAL
{
    public class DoacaoDeAlimentosContext : DbContext
    {

        public DoacaoDeAlimentosContext() : base("DoacaoDeAlimentosContext")
        {
        }

        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Distribuidor> Distribuidors { get; set; }
        public DbSet<Doacao> Doacaos { get; set; }
        public DbSet<Doador> Doadors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}