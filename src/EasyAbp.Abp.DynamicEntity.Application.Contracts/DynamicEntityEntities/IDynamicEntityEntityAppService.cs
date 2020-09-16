using System;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public interface IDynamicEntityEntityAppService : ICrudAppService<
        DynamicEntityEntityDto,
        Guid,
        GetListInput,
        CreateUpdateDynamicEntityEntityDto,
        CreateUpdateDynamicEntityEntityDto>
    {
    }
}