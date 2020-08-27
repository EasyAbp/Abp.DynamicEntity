using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public static class DynamicFieldEntityTypeBuilderExtensions
    {
        public static void ConfigureDynamicField<T>(this EntityTypeBuilder<T> b)
            where T : class, IDynamicModel
        {
            b.HasOne(e => e.ModelDefinition)
                .WithMany()
                .HasForeignKey(x => x.ModelDefinitionId)
                ;
        }
    }
}