using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public static class DynamicFieldEntityTypeBuilderExtensions
    {
        public static void ConfigureDynamicField<T>(this EntityTypeBuilder<T> b)
            where T : class, IDynamicField
        {
            b.HasOne(e => e.FieldDefinition)
                .WithMany()
                .HasForeignKey(x => x.FieldDefinitionId)
                ;
        }
    }
}