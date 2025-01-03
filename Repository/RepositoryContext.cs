using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Following line for identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguaration());

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(static warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }


    }
}
