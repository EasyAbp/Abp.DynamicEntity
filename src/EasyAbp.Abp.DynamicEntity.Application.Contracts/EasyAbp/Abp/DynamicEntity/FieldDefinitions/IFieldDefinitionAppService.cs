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
            CreateFieldDefinitionDto,
            UpdateFieldDefinitionDto>
    {
        Task<FieldDefinitionDto> GetByName(string name);
    }
}