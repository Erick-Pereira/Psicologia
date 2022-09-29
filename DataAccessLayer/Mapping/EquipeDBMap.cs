using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    internal class EquipeDBMap : IEntityTypeConfiguration<Equipe>
    {
        /// <summary>
        /// Faz a Configuração da Tabela de Equipe no Banco de Dados (NO MOMENTO NÃO ESTA SENDO ULTILIZADA)
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("EQUIPES");
        }
    }
}