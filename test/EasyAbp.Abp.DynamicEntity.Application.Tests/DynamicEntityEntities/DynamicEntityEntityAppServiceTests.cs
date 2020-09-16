using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public class DynamicEntityEntityAppServiceTests : DynamicEntityApplicationTestBase
    {
        private readonly IDynamicEntityEntityAppService _dynamicEntityAppService;
        private readonly IDynamicEntityEntityRepository _dynamicEntityRepository;

        public DynamicEntityEntityAppServiceTests()
        {
            _dynamicEntityAppService = GetRequiredService<IDynamicEntityEntityAppService>();
            _dynamicEntityRepository = GetRequiredService<IDynamicEntityEntityRepository>();
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
            var output = await _dynamicEntityAppService.GetListAsync(new GetListInput
                {
                    FieldFilters = new List<Dtos.Filter>
                    {
                        new Dtos.Filter {FieldName = "name", Operator = Operator.Contain, Value = "1"}
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