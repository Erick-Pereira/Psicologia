using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    internal class SF36DBMap : IEntityTypeConfiguration <SF36Score>
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
            builder.ToTable("SF36_Score");

        }
    }
}
