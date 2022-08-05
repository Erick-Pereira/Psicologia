using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcessLayer
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Douglas\source\repos\TheShelow\Psicologia\DataBase\NoNameDB.mdf;Integrated Security=True;Connect Timeout=30", options => options.EnableRetryOnFailure(5));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //List<Type> types = Assembly.GetExecutingAssembly().GetTypes().ToList();
            //Mandrake m = new Mandrake();
            //object o = Assembly.GetAssembly(typeof(Cargo))
            //        .GetTypes()
            //        .FirstOrDefault(c => c.IsClass && c.Name == "Mandrake")
            //        .GetConstructors()[0].Invoke(null);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}