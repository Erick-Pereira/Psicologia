using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class SF36DBMap : IEntityTypeConfiguration<SF36Score>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de SF36 no Banco de Dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<SF36Score> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn(1, 1);
            builder.Property(c => c.AspectosSociais).IsRequired();
            builder.Property(c => c.CapacidadeFuncional).IsRequired();
            builder.Property(c => c.SaudeMental).IsRequired();
            builder.Property(c => c.EstadoSaude).IsRequired();
            builder.Property(c => c.LimitacaoAspectosFisicos).IsRequired();
            builder.Property(c => c.AspectosEmocionais).IsRequired();
            builder.Property(c => c.Vitalidade).IsRequired();
            builder.ToTable("SF36_SCORE");
        }
    }
}