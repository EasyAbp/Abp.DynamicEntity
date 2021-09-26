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
            GetModelDefinitionListInput,
            CreateModelDefinitionDto,
            UpdateModelDefinitionDto>
    {
        Task<ModelDefinitionDto> GetByName(string name);
    }
}