using crud.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace crud.Infrastructure
{
    internal class crudDbContextExample : DbContext
    {
        public DbSet<Account> account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\caminho\\para\\seu\\banco.mdf;Integrated Security=True;");

        }
    }
   
}
