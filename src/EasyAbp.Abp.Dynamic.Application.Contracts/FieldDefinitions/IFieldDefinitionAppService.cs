using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public interface IFieldDefinitionAppService :
        ICrudAppService< 
            FieldDefinitionDto, 
            Guid, 
            GetListInput,
            CreateUpdateFieldDefinitionDto,
            CreateUpdateFieldDefinitionDto>
    {
        Task<FieldDefinitionDto> GetByName(string name);
    }
}