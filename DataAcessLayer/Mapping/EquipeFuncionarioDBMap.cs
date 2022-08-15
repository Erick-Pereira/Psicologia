using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.Mapping
{
    internal class EquipeFuncionarioDBMap : IEntityTypeConfiguration<EquipeFuncionario>
    {
        public void Configure(EntityTypeBuilder<EquipeFuncionario> builder)
        {
            builder.ToTable("EQUIPE_FUNCIONARIO");
        }
    }
}