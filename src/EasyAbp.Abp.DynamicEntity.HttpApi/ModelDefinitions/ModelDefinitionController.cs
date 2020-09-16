using System;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    [RemoteService(Name = "EasyAbpDynamicEntity")]
    [Route("/api/dynamic/modelDefinition")]
    public class ModelDefinitionController : DynamicEntityController, IModelDefinitionAppService
    {
        private readonly IModelDefinitionAppService _service;

        public ModelDefinitionController(IModelDefinitionAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual Task<ModelDefinitionDto> CreateAsync(CreateUpdateModelDefinitionDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ModelDefinitionDto> UpdateAsync(Guid id, CreateUpdateModelDefinitionDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public Task<ModelDefinitionDto> GetByName(string name)
        {
            return _service.GetByName(name);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ModelDefinitionDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ModelDefinitionDto>> GetListAsync(GetListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}