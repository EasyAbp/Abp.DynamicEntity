using EasyAbp.Abp.Dynamic.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace DynamicSample.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See DynamicSampleDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class DynamicSampleMigrationsDbContext : AbpDbContext<DynamicSampleMigrationsDbContext>
    {
        public DynamicSampleMigrationsDbContext(DbContextOptions<DynamicSampleMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();
            
            /* Include dynamic module */
            builder.ConfigureDynamic();

            /* Configure your own tables/entities inside the ConfigureDynamicSample method */

            builder.ConfigureDynamicSample();
        }
    }
}