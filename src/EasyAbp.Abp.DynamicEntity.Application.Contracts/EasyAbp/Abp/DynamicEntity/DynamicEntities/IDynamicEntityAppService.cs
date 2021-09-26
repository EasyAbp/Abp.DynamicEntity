using System;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public interface IDynamicEntityAppService : ICrudAppService<
        DynamicEntityDto,
        Guid,
        GetDynamicEntityListInput,
        CreateDynamicEntityDto,
        UpdateDynamicEntityDto>
    {
    }
}