using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public static class DynamicEntityModelEntityTypeBuilderExtensions
    {
        public static void ConfigureAbpDynamicEntityModel<T>(this EntityTypeBuilder<T> b)
            where T : class, IDynamicEntityModel
        {
            b.HasOne(e => e.ModelDefinition)
                .WithMany()
                .HasForeignKey(x => x.ModelDefinitionId)
                .OnDelete(DeleteBehavior.SetNull)
                ;
        }
    }
}