using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class EquipeDBap
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("EQUIPES");
        }
    }
}