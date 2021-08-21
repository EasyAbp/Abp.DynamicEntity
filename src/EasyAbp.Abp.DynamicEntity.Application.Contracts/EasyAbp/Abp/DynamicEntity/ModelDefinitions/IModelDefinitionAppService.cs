using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public interface IModelDefinitionAppService :
        ICrudAppService<
            ModelDefinitionDto,
            Guid,
            GetListInput,
            CreateUpdateModelDefinitionDto,
            CreateUpdateModelDefinitionDto>
    {
        Task<ModelDefinitionDto> GetByName(string name);
    }
}