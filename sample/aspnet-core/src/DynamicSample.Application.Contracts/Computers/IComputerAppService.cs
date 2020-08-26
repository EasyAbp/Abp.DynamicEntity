using System;
using DynamicSample.Computers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicSample.Computers
{
    public interface IComputerAppService :
        ICrudAppService< 
            ComputerDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateComputerDto,
            CreateUpdateComputerDto>
    {

    }
}