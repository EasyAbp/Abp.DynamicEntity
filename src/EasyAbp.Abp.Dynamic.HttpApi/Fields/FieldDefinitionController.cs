using System;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace EasyAbp.Abp.Dynamic.Fields
{
    [RemoteService(Name = "DynamicFieldDefinition")]
    [Route("/api/dynamic/fieldDefinition")]
    public class FieldDefinitionController : DynamicController, IFieldDefinitionAppService
    {
        private readonly IFieldDefinitionAppService _service;

        public FieldDefinitionController(IFieldDefinitionAppService service)
        {
            _service = service;
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
        public virtual Task<PagedResultDto<FieldDefinitionDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}