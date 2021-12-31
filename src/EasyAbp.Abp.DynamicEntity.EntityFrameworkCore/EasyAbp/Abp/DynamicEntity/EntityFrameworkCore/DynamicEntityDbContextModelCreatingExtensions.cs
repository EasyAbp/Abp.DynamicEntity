using System;
using System.Linq;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore
{
    public static class DynamicEntityDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpDynamicEntity(
            this ModelBuilder builder,
            Action<DynamicEntityModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicEntityModelBuilderConfigurationOptions(
                DynamicEntityDbProperties.DbTablePrefix,
                DynamicEntityDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<FieldDefinition>(b =>
            {
                b.ToTable(options.TablePrefix + "FieldDefinitions", options.Schema);
                b.ConfigureByConvention();
                
                b.Property(x => x.Name).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxNameLength);
                b.Property(x => x.DisplayName).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxDisplayNameLength);
                b.Property(x => x.Type).IsRequired().HasMaxLength(FieldDefinitionConsts.MaxTypeLength);
                
                b.HasIndex(x => x.Name);
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

                b.OwnsOne(x => x.PermissionSet);

                b.HasIndex(x => x.Name);
            });
            
            builder.Entity<ModelField>(b =>
            {
                b.ToTable(options.TablePrefix + "ModelFields", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(x => new {x.FieldDefinitionId, x.ModelDefinitionId});

                b.HasOne(x => x.FieldDefinition)
                    .WithMany()
                    .HasForeignKey(x => x.FieldDefinitionId);
            });
            
            builder.Entity<DynamicEntities.DynamicEntity>(b =>
            {
                b.ToTable(options.TablePrefix + "DynamicEntities", options.Schema);
                b.ConfigureByConvention();
                b.ConfigureAbpDynamicEntityModel();

                b.HasIndex(x => x.ExtraProperties);
            });

            // register JSON function to EF
            string jsonFunction;
            if (builder.IsUsingSqlite())
            {
                jsonFunction = "JSON_EXTRACT";
            }
            else
            {
                jsonFunction = "JSON_VALUE";
            }
            builder.HasDbFunction(typeof(DbFunctions).GetMethod(nameof(DbFunctions.JsonValue))!)
                .HasTranslation(e => SqlFunctionExpression.Create(
                    jsonFunction, new SqlExpression[]
                    {
                        new SqlFragmentExpression("ExtraProperties"),
                        e.ToArray()[0]
                    }, typeof(string), null));
            
        }
    }
}