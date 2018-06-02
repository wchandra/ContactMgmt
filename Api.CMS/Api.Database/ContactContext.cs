 
using Microsoft.EntityFrameworkCore;
using System.Configuration.Assemblies;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Api.Database
{
   public class ContactContext:DbContext
    {
        public ContactContext()    
        {

        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
               
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(AppConfiguration.connectionString);
        }


    }
}
