using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicQuery;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore.DynamicEntityEntities
{
    public class DynamicEntityEntityRepositoryTests : DynamicEntityEntityFrameworkCoreTestBase
    {
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityEntityRepositoryTests()
        {
            _dynamicEntityRepository = GetRequiredService<IDynamicEntityRepository>();
        }

        [Fact]
        public async Task ShouldGetQueryByDictionaryFilter()
        {
            await WithUnitOfWorkAsync(async () =>
            {

                // Arrange
                var filters = new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "price", Operator = DynamicQueryOperator.Contain, Value = 100}
                };

                // Act
                var output = await _dynamicEntityRepository.GetQueryByFilter(filters).ToListAsync();

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
                var filters = new List<DynamicQueryFilter>
                {
                    new DynamicQueryFilter {FieldName = "a", Operator = DynamicQueryOperator.Contain, Value = "1 OR 1 = 1; --"}
                };
                // Act
                var output = await _dynamicEntityRepository.GetQueryByFilter(filters).ToListAsync();

                // Assert
                output.Count.ShouldBe(0);
            });
        }
        
        
        [Fact]
        public async Task ShouldGetQueryByStringFilter()
        {
            await WithUnitOfWorkAsync(async () =>
            {

                // Arrange
                var filter = "200";

                // Act
                var output = await _dynamicEntityRepository.GetQueryByFilter(filter).ToListAsync();

                // Assert
                output.Count.ShouldBe(1);
                output[0].GetProperty("Name", "Book2");
            });
        }
    }
}