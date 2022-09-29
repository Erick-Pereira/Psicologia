using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class CidadeDBMap : IEntityTypeConfiguration<Cidade>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de Cidade no Banco de Dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(c => c.NomeCidade).IsUnicode(false).IsRequired();
            builder.ToTable("CIDADES");
        }
    }
}