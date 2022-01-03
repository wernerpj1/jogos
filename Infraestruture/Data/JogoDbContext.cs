using Jogos.Business.Entities;
using Jogos.Infraestruture.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Jogos.Infraestruture.Data
{
    public class JogoDbContext : DbContext
    {
        public JogoDbContext(DbContextOptions<JogoDbContext> options) :base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JogoMapping());
            modelBuilder.ApplyConfiguration(new UserMapping()); 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

    }
}