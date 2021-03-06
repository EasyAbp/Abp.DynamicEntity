﻿using EasyAbp.Abp.DynamicEntity;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace DynamicEntitySample
{
    [DependsOn(
        typeof(DynamicEntitySampleDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(DynamicEntitySampleApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    [DependsOn(typeof(DynamicEntityApplicationModule))]
    public class DynamicEntitySampleApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DynamicEntitySampleApplicationModule>();
            });
        }
    }
}
