using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class CompromissoDBMap : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.Property(c => c.DataInicio).IsRequired();
            builder.Property(c => c.DataInicio).IsRequired();
            builder.Property(c => c.Descricao).IsUnicode(false).IsRequired();
            builder.ToTable("COMPROMISSO");
        }
    }
}