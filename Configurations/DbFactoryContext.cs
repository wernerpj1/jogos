using Jogos.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace back.Configurations
{
    public class DbFactoryContext : IDesignTimeDbContextFactory<JogoDbContext>
    {

        public JogoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JogoDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-2DVH51E\\SQLEXPRESS; Database= Jogos; user = sa; password = Deusminhavida!32756");
            JogoDbContext contexto = new JogoDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
