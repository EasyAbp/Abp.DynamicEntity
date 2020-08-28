using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.DynamicEntities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore.DynamicEntities
{
    public class DynamicEntityRepositoryTests : DynamicEntityFrameworkCoreTestBase
    {
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityRepositoryTests()
        {
            _dynamicEntityRepository = GetRequiredService<IDynamicEntityRepository>();
        }

        [Fact]
        public async Task ShouldGetQueryByFilter()
        {
            await WithUnitOfWorkAsync(async () =>
            {

                // Arrange
                var filter = new Dictionary<string, string> {{"Price", "100"}};

                // Act
                var output = await _dynamicEntityRepository.GetQueryByFilter(filter).ToListAsync();

                // Assert
                output.Count.ShouldBe(1);
                output[0].GetProperty("Name", "Book1");
            });
        }
        
        [Fact]
        public async Task ShouldPreventSqlInjection()
        {
            await WithUnitOfWorkAsync(async () =>
            {

                // Arrange
                var filter = new Dictionary<string, string> {{"a", "1 OR 1 = 1; --"}};

                // Act
                var output = await _dynamicEntityRepository.GetQueryByFilter(filter).ToListAsync();

                // Assert
                output.Count.ShouldBe(0);
            });
        }
    }
}