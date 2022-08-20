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
            builder.HasIndex(f => f.Cpf).IsUnique().HasDatabaseName("UQ_FUNCIONARIO_CPF");
            builder.HasIndex(f => f.Email).IsUnique().HasDatabaseName("UQ_FUNCIONARIO_EMAIL");
            builder.Property(f => f.Cpf).HasMaxLength(FuncionarioConstants.TAMANHO_CPF + 3).IsUnicode(false).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_EMAIL).IsUnicode(false).IsRequired();
            builder.Property(f => f.Nome).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME).IsUnicode(false).IsRequired();
            builder.Property(f => f.Senha).IsUnicode(false).IsRequired();
            builder.Property(f => f.HasRequiredTest).HasDefaultValue(false);
            builder.Property(f => f.IsFirstLogin).HasDefaultValue(true);
            builder.Property(f => f.IsAtivo).HasDefaultValue(true);
            builder.Property(f => f.Celular).IsUnicode(false).IsRequired(false);
            builder.Property(f => f.Foto).IsUnicode(false).IsRequired(false);
            builder.Property(f => f.EnderecoID).HasDefaultValue(1);
            builder.ToTable("FUNCIONARIOS");
        }
    }
}