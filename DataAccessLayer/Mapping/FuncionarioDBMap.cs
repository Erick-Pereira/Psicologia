using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;

namespace DataAccessLayer.Mapping
{
    internal class FuncionarioDBMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasIndex(f => f.Cpf).IsUnique().HasDatabaseName("UQ_FUNCIONARIO_CPF");
            builder.HasIndex(f => f.Email).IsUnique().HasDatabaseName("UQ_FUNCIONARIO_EMAIL");
            builder.Property(f => f.Celular).IsUnicode(false).IsRequired(false);
            builder.Property(f => f.Cpf).HasMaxLength(FuncionarioConstants.TAMANHO_CPF + 3).IsUnicode(false).IsRequired();
            builder.Property(f => f.Email).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_EMAIL).IsUnicode(false).IsRequired();
            builder.Property(f => f.EnderecoID).HasDefaultValue(1);
            builder.Property(f => f.HasRequiredTest);
            builder.Property(f => f.IsAtivo);
            builder.Property(f => f.IsFirstLogin);
            builder.Property(f => f.Nome).HasMaxLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME).IsUnicode(false).IsRequired();
            builder.Property(f => f.Salario).IsRequired();
            builder.Property(f => f.Senha).IsUnicode(false).IsRequired();
            builder.ToTable("FUNCIONARIOS");
        }
    }
}