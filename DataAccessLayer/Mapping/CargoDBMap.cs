using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class CargoDBMap : IEntityTypeConfiguration<Cargo>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de Cargo no Banco de Dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasIndex(c => c.Funcao).IsUnique();
            builder.Property(c => c.Funcao).IsUnicode(false).IsRequired();
            builder.Property(c => c.NivelPermissao).IsRequired();
            builder.ToTable("CARGOS");
        }
    }
}