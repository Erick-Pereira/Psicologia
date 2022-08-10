using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcessLayer
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Equipe> Equipe { get; set; }

        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipeFuncionario>().HasKey(ef => new { ef.EquipeID, ef.FuncionarioID });
            modelBuilder.Entity<EquipeFuncionario>().HasOne(e => e.Equipe).WithMany(e => e.Funcionarios).HasForeignKey(e => e.EquipeID);
            modelBuilder.Entity<EquipeFuncionario>().HasOne(E => E.Funcionario).WithMany(E => E.Equipes).HasForeignKey(E => E.FuncionarioID);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}