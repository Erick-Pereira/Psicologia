using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
