using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcessLayer
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipeFuncionario>().HasKey(ef => new { ef.EquipeID, ef.FuncionarioID });
            modelBuilder.Entity<EquipeFuncionario>().HasOne(E => E.Equipe).WithMany(E => E.Funcionarios).HasForeignKey(E => E.EquipeID);
            modelBuilder.Entity<EquipeFuncionario>().HasOne(F => F.Funcionario).WithMany(F => F.Equipes).HasForeignKey(F => F.FuncionarioID);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}