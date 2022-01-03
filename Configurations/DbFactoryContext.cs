using Jogos;
using Jogos.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace back.Configurations
{
    public class DbFactoryContext : IDesignTimeDbContextFactory<JogoDbContext>
    {
        

        public JogoDbContext CreateDbContext(string[] args)
        {
             // Replace with your connection string.
    

        // Replace with your server version and type.
        // Use 'MariaDbServerVersion' for MariaDB.
        // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
        // For common usages, see pull request #1233.
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            var optionsBuilder = new DbContextOptionsBuilder<JogoDbContext>();
            //optionsBuilder.UseSqlServer("Server=localhost; Database=Jogos; user = root; password=verni;");
            optionsBuilder.UseMySql("server=localhost; user=riddle; port=3306; password=verni; database=jogos; Persist Security Info=False; Connect Timeout=300", serverVersion);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            
            JogoDbContext contexto = new JogoDbContext(optionsBuilder.Options);
            var migracoesPendentes = contexto.Database.GetPendingMigrations();
            if (migracoesPendentes.Count() > 0)
            {
                contexto.Database.Migrate();
            }
            return contexto;
        }
    }
}
