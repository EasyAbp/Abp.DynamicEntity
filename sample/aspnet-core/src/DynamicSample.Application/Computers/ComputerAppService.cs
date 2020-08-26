using System;
using DynamicSample.Computers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DynamicSample.Computers
{
    public class ComputerAppService : CrudAppService<Computer, ComputerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateComputerDto, CreateUpdateComputerDto>,
        IComputerAppService
    {

        public ComputerAppService(IRepository<Computer, Guid> repository) : base(repository)
        {
        }
    }
}
