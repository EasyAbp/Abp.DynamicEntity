using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Filters;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore.DynamicEntities
{
    public class DynamicEntityEntityRepositoryTests : DynamicEntityEntityFrameworkCoreTestBase
    {
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityEntityRepositoryTests()
        {
            _dynamicEntityRepository = GetRequiredService<IDynamicEntityRepository>();
        }

        [Fact(Skip = "Wait for https://github.com/zzzprojects/System.Linq.Dynamic.Core/issues/422")]
        public async Task ShouldGetQueryByListFilter()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange
                var filters = new DynamicQueryGroup
                {
                    Type = GroupType.Add,
                    Conditions = new List<DynamicQueryCondition>
                    {
                        new DynamicQueryCondition {FieldName = "price", Operator = DynamicQueryOperator.GreaterOrEqual, Value = 200}
                    },
                };

                // Act
                var output = await _dynamicEntityRepository.ExecuteDynamicQuery(filters).ToListAsync();

                // Assert
                output.Count.ShouldBe(1);
                output[0].GetProperty("Name", "Book2");
            });
        }

        [Fact]
        public async Task ShouldPreventSqlInjection()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange
                var filters = new DynamicQueryGroup
                {
                    Type = GroupType.Add,
                    Conditions = new List<DynamicQueryCondition>
                    {
                        new DynamicQueryCondition {FieldName = "a", Operator = DynamicQueryOperator.Contain, Value = "1 OR 1 = 1; --"}
                    }
                };

                // Act
                var output = await _dynamicEntityRepository.ExecuteDynamicQuery(filters).ToListAsync();

                // Assert
                output.Count.ShouldBe(0);
            });
        }
    }
}