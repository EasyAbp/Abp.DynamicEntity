using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos;
using EasyAbp.Abp.DynamicQuery;
using EasyAbp.Abp.DynamicQuery.Filters;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities
{
    public class DynamicEntityEntityAppServiceTests : DynamicEntityApplicationTestBase
    {
        private readonly IDynamicEntityAppService _dynamicEntityAppService;
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityEntityAppServiceTests()
        {
            _dynamicEntityAppService = GetRequiredService<IDynamicEntityAppService>();
            _dynamicEntityRepository = GetRequiredService<IDynamicEntityRepository>();
        }

        [Fact]
        public async Task ShouldIncludeModelDefinition()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange
                var deBook = _dynamicEntityRepository
                        .WithDetails()
                        .First(de => de.ModelDefinition.Name == "book")
                    ;

                // Act
                var output = await _dynamicEntityAppService.GetAsync(deBook.Id);

                // Assert
                output.GetProperty("name").ShouldBe(deBook.GetProperty("name"));
                output.ModelDefinition.ShouldNotBeNull();
                output.ModelDefinition.Name.ShouldBe("book");
                output.ModelDefinition.DisplayName.ShouldBe("Book");
                output.ModelDefinition.Fields.Count.ShouldBe(2);
            });
        }

        [Fact]
        public async Task ShouldFilterByField()
        {
            // Arrange

            // Act
            var output = await _dynamicEntityAppService.GetListAsync(new GetDynamicEntityListInput
                {
                    FilterGroup = new DynamicQueryGroup
                    {
                        Type = GroupType.And,
                        Conditions = new List<DynamicQueryCondition>
                        {
                            new DynamicQueryCondition{FieldName = "name", Operator = DynamicQueryOperator.Contain, Value = "1"}
                        },
                    }
                }
            );

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].GetProperty<string>("name").ShouldBe("Book1");
            output.Items[0].GetProperty<float>("price").ShouldBe(100f);
        }
    }
}