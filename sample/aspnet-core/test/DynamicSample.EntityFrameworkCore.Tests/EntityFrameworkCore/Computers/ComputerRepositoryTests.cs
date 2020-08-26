using System;
using System.Threading.Tasks;
using DynamicSample.Computers;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DynamicSample.EntityFrameworkCore.Computers
{
    public class ComputerRepositoryTests : DynamicSampleEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Computer, Guid> _computerRepository;

        public ComputerRepositoryTests()
        {
            _computerRepository = GetRequiredService<IRepository<Computer, Guid>>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
