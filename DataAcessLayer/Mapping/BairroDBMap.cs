using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class BairroDBMap : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.Property(b => b.NomeBairro).IsUnicode(false).IsRequired();
            builder.ToTable("BAIRROS");
        }
    }
}