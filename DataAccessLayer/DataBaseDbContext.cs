using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Compromisso> Compromisso { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<SF36Score> Score { get; set; }

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