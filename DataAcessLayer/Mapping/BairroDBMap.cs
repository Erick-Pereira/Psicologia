using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class BairroDBMap : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.ToTable("BAIRROS");
        }
    }
}