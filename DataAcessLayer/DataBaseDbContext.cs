using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcessLayer
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}