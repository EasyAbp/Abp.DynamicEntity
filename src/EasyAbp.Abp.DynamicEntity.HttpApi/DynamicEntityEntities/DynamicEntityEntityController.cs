using System;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    [RemoteService(Name = "EasyAbpDynamicEntity")]
    [Route("/api/dynamic/dynamicEntity")]
    public class DynamicEntityEntityController : DynamicEntityController, IDynamicEntityEntityAppService
    {
        private readonly IDynamicEntityEntityAppService _service;

        public DynamicEntityEntityController(IDynamicEntityEntityAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual Task<DynamicEntityEntityDto> CreateAsync(CreateUpdateDynamicEntityEntityDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DynamicEntityEntityDto> UpdateAsync(Guid id, CreateUpdateDynamicEntityEntityDto input)
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
        public virtual Task<DynamicEntityEntityDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DynamicEntityEntityDto>> GetListAsync(GetListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}