using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
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