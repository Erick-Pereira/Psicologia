﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class CidadeDBMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(c => c.Estado).IsUnicode(false).IsRequired();
            builder.Property(c => c.NomeCidade).IsUnicode(false).IsRequired();
            builder.ToTable("CIDADES");
        }
    }
}