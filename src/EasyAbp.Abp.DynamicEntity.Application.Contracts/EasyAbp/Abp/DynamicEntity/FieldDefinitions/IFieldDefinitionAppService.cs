using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    public interface IFieldDefinitionAppService :
        ICrudAppService< 
            FieldDefinitionDto, 
            Guid, 
            GetFieldDefinitionListInput,
            CreateUpdateFieldDefinitionDto,
            CreateUpdateFieldDefinitionDto>
    {
        Task<FieldDefinitionDto> GetByName(string name);
    }
}