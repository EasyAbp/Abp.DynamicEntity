using System;
using EasyAbp.Abp.Dynamic.DynamicEntities;
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
                
                b.Property(x => x.Name).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxNameLength);
                b.Property(x => x.DisplayName).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxDisplayNameLength);
                b.Property(x => x.Type).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxTypeLength);
            });

            builder.Entity<ModelDefinition>(b =>
            {
                b.ToTable(options.TablePrefix + "ModelDefinitions", options.Schema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(ModelDefinitionConsts.MaxNameLength);
                b.Property(x => x.DisplayName).IsRequired().HasMaxLength(ModelDefinitionConsts.MaxDisplayNameLength);
                b.Property(x => x.Type).IsRequired().HasMaxLength(ModelDefinitionConsts.MaxTypeLength);

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

                b.HasOne(x => x.FieldDefinition)
                    .WithMany()
                    .HasForeignKey(x => x.FieldDefinitionId);

                b.HasOne(x => x.ModelDefinition)
                    .WithMany(x => x.Fields)
                    .HasForeignKey(x => x.ModelDefinitionId)
                    ;
            });
            
            builder.Entity<DynamicEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "DynamicEntities", options.Schema);
                b.ConfigureByConvention();
                b.ConfigureDynamicModel();
            });
        }
    }
}