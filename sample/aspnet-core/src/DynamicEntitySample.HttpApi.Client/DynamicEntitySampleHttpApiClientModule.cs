﻿using EasyAbp.Abp.DynamicEntity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace DynamicEntitySample
{
    [DependsOn(
        typeof(DynamicEntitySampleApplicationContractsModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule)
    )]
    [DependsOn(typeof(DynamicEntityHttpApiClientModule))]
    public class DynamicEntitySampleHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DynamicEntitySampleApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
