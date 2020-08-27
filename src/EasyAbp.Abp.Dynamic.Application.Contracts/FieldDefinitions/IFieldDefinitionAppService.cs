using System;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public interface IFieldDefinitionAppService :
        ICrudAppService< 
            FieldDefinitionDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateFieldDefinitionDto,
            CreateUpdateFieldDefinitionDto>
    {

    }
}