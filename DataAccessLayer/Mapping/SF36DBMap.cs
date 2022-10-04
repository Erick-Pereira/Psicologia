using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class SF36DBMap : IEntityTypeConfiguration<SF36Score>
    {
        public void Configure(EntityTypeBuilder<SF36Score> builder)
        {
            builder.Property(c => c.AspectosSociais).IsRequired();
            builder.Property(c => c.CapacidadeFuncional).IsRequired();
            builder.Property(c => c.SaudeMental).IsRequired();
            builder.Property(c => c.EstadoSaude).IsRequired();
            builder.Property(c => c.LimitacaoAspectosFisicos).IsRequired();
            builder.Property(c => c.AspectosEmocionais).IsRequired();
            builder.Property(c => c.Vitalidade).IsRequired();
            builder.Property(c => c.DataSF).IsRequired();
            builder.Property(c => c.ComparacaoSaude).IsRequired().IsUnicode(false);
            builder.ToTable("SF36_SCORE");
        }
    }
}