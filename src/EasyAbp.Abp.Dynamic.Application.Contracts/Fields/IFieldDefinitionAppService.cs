using System;
using EasyAbp.Abp.Dynamic.Fields.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.Fields
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