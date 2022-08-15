using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;

namespace DataAcessLayer.Mapping
{
    internal class FuncionarioDBMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIOS");
            builder.Property(f => f.Nome).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME).IsUnicode(false).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_EMAIL).IsRequired();
            builder.HasIndex(f => f.Email).IsUnique().HasDatabaseName("UQ_FUNCIONARIO_EMAIL");
            //builder.Property(f => f.EnderecoID).HasDefaultValue(1);
            //builder.Property(f => f.CargoID).HasDefaultValue(2);
        }
    }
}