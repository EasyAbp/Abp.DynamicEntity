using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace EasyAbp.Abp.DynamicEntity.Authorization
{
    public class BasicDynamicEntityOperationAuthorizationHandler : DynamicEntityOperationAuthorizationHandler, ISingletonDependency
    {
        private readonly IPermissionChecker _permissionChecker;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;

        public BasicDynamicEntityOperationAuthorizationHandler(
            IPermissionChecker permissionChecker,
            ICurrentPrincipalAccessor currentPrincipalAccessor)
        {
            _permissionChecker = permissionChecker;
            _currentPrincipalAccessor = currentPrincipalAccessor;
        }
        
        protected virtual async Task SetSucceedIfHasPermissionAsync([CanBeNull] string permission,
            AuthorizationHandlerContext context, DynamicEntityOperationAuthorizationRequirement requirement)
        {
            if (!_currentPrincipalAccessor.Principal.Identity.IsAuthenticated)
            {
                return;
            }

            if (!permission.IsNullOrWhiteSpace() && !await _permissionChecker.IsGrantedAsync(permission))
            {
                return;
            }

            context.Succeed(requirement);
        }

        protected override async Task HandleGetAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (resource.ModelDefinition.PermissionSet.AnonymousGet)
            {
                context.Succeed(requirement);
                return;
            }
            
            await SetSucceedIfHasPermissionAsync(resource.ModelDefinition.PermissionSet.Get, context, requirement);
        }

        protected override async Task HandleGetListAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (resource.ModelDefinition.PermissionSet.AnonymousGetList)
            {
                context.Succeed(requirement);
                return;
            }
            
            await SetSucceedIfHasPermissionAsync(resource.ModelDefinition.PermissionSet.GetList, context, requirement);
        }

        protected override async Task HandleCreateAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (resource.ModelDefinition.PermissionSet.AnonymousCreate)
            {
                context.Succeed(requirement);
                return;
            }
            
            await SetSucceedIfHasPermissionAsync(resource.ModelDefinition.PermissionSet.Create, context, requirement);
        }

        protected override async Task HandleUpdateAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (resource.ModelDefinition.PermissionSet.AnonymousUpdate)
            {
                context.Succeed(requirement);
                return;
            }
            
            await SetSucceedIfHasPermissionAsync(resource.ModelDefinition.PermissionSet.Update, context, requirement);
        }

        protected override async Task HandleDeleteAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (resource.ModelDefinition.PermissionSet.AnonymousDelete)
            {
                context.Succeed(requirement);
                return;
            }
            
            await SetSucceedIfHasPermissionAsync(resource.ModelDefinition.PermissionSet.Delete, context, requirement);
        }
    }
}