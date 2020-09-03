using System;
using EasyAbp.Abp.Dynamic.DynamicEntities.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    [RemoteService(Name = "EasyAbpDynamic")]
    [Route("/api/dynamic/dynamicEntity")]
    public class DynamicEntityController : DynamicController, IDynamicEntityAppService
    {
        private readonly IDynamicEntityAppService _service;

        public DynamicEntityController(IDynamicEntityAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual Task<DynamicEntityDto> CreateAsync(CreateUpdateDynamicEntityDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DynamicEntityDto> UpdateAsync(Guid id, CreateUpdateDynamicEntityDto input)
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
        public virtual Task<DynamicEntityDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<DynamicEntityDto>> GetListAsync(GetListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}