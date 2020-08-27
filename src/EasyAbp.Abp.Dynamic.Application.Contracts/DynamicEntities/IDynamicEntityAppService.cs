using System;
using EasyAbp.Abp.Dynamic.DynamicEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public interface IDynamicEntityAppService : ICrudAppService<
        DynamicEntityDto,
        Guid,
        GetListInput,
        CreateUpdateDynamicEntityDto,
        CreateUpdateDynamicEntityDto>
    {
    }
}