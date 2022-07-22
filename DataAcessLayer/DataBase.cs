using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcessLayer
{
    public class DataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
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