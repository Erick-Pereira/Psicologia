using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class EstadoDBMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("ESTADOS");
        }
    }
}