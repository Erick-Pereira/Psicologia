using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class BairroDBMap : IEntityTypeConfiguration<Bairro>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de Bairro no Banco de Dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.Property(b => b.NomeBairro).IsUnicode(false).IsRequired();
            builder.ToTable("BAIRROS");
        }
    }
}