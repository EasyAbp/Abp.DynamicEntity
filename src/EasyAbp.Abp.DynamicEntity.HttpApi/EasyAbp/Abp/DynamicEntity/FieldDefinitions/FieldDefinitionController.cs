using System;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    [RemoteService(Name = "EasyAbpDynamicEntity")]
    [Route("/api/abp/dynamic-entity/field-definition")]
    public class FieldDefinitionController : DynamicEntityController, IFieldDefinitionAppService
    {
        private readonly IFieldDefinitionAppService _service;

        public FieldDefinitionController(IFieldDefinitionAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("by-name/{name}")]
        public virtual Task<FieldDefinitionDto> GetByName(string name)
        {
            return _service.GetByName(name);
        }

        [HttpPost]
        public virtual Task<FieldDefinitionDto> CreateAsync(CreateUpdateFieldDefinitionDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<FieldDefinitionDto> UpdateAsync(Guid id, CreateUpdateFieldDefinitionDto input)
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
        [Route("{id}")]
        public virtual Task<FieldDefinitionDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<FieldDefinitionDto>> GetListAsync(GetFieldDefinitionListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}