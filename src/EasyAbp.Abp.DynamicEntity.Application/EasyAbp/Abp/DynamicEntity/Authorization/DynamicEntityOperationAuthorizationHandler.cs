using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EasyAbp.Abp.DynamicEntity.Authorization
{
    public abstract class DynamicEntityOperationAuthorizationHandler : AuthorizationHandler<
        DynamicEntityOperationAuthorizationRequirement, DynamicEntityOperationInfoModel>
    {
        protected string[] SpecifiedModelNames { get; set; }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource)
        {
            if (!SpecifiedModelNames.IsNullOrEmpty() && !SpecifiedModelNames.Contains(resource.ModelDefinition.Name))
            {
                return;
            }
            
            switch (requirement.Name)
            {
                case DynamicEntityOperationAuthorizationRequirement.GetName:
                    await HandleGetAsync(context, requirement, resource);
                    break;
                case DynamicEntityOperationAuthorizationRequirement.GetListName:
                    await HandleGetListAsync(context, requirement, resource);
                    break;
                case DynamicEntityOperationAuthorizationRequirement.CreateName:
                    await HandleCreateAsync(context, requirement, resource);
                    break;
                case DynamicEntityOperationAuthorizationRequirement.UpdateName:
                    await HandleUpdateAsync(context, requirement, resource);
                    break;
                case DynamicEntityOperationAuthorizationRequirement.DeleteName:
                    await HandleDeleteAsync(context, requirement, resource);
                    break;
            }
        }

        protected abstract Task HandleGetAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource);

        protected abstract Task HandleGetListAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource);

        protected abstract Task HandleCreateAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource);

        protected abstract Task HandleUpdateAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource);

        protected abstract Task HandleDeleteAsync(AuthorizationHandlerContext context,
            DynamicEntityOperationAuthorizationRequirement requirement, DynamicEntityOperationInfoModel resource);
    }
}