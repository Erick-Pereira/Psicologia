﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class EstadoDBMap : IEntityTypeConfiguration<Estado>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de Estado no Banco de Dados
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasIndex(e => e.NomeEstado).IsUnique();
            builder.HasIndex(e => e.Sigla).IsUnique();
            builder.Property(e => e.NomeEstado).IsUnicode(false).IsRequired();
            builder.Property(e => e.Sigla).HasMaxLength(3).IsUnicode(false).IsRequired();
            builder.ToTable("ESTADOS");
        }
    }
}