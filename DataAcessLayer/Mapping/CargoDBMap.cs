using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class CargoDBMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("CARGOS");
        }
    }
}