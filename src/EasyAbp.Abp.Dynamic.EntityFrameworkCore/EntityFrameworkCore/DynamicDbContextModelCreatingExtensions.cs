using System;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore
{
    public static class DynamicDbContextModelCreatingExtensions
    {
        public static void ConfigureDynamic(
            this ModelBuilder builder,
            Action<DynamicModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicModelBuilderConfigurationOptions(
                DynamicDbProperties.DbTablePrefix,
                DynamicDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<FieldDefinition>(b =>
            {
                b.ToTable(options.TablePrefix + "FieldDefinitions", options.Schema);
                b.ConfigureByConvention();
            });

            builder.Entity<ModelDefinition>(b =>
            {
                b.ToTable(options.TablePrefix + "ModelDefinitions", options.Schema);
                b.ConfigureByConvention();

                b.HasMany(x => x.Fields)
                    .WithOne()
                    .HasForeignKey(x => x.ModelDefinitionId)
                    ;
            });
            
            builder.Entity<ModelField>(b =>
            {
                b.ToTable(options.TablePrefix + "ModelFields", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(x => new {x.FieldDefinitionId, x.ModelDefinitionId});
            });

        }
    }
}