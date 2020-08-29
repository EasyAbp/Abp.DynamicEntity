using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.DynamicEntities.Dtos;
using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntityAppServiceTests : DynamicApplicationTestBase
    {
        private readonly IDynamicEntityAppService _dynamicEntityAppService;
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityAppServiceTests()
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
                        .First(de => de.ModelDefinition.Name == "Book")
                    ;
                // Act
                var output = await _dynamicEntityAppService.GetAsync(deBook.Id);

                // Assert
                output.GetProperty("Name").ShouldBe(deBook.GetProperty("Name"));
                output.ModelDefinition.ShouldNotBeNull();
                output.ModelDefinition.Name.ShouldBe("Book");
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
                    Filter = new Dictionary<string, string> {{"Name", "1"}}
                }
            );

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].GetProperty<string>("Name").ShouldBe("Book1");
            output.Items[0].GetProperty<float>("Price").ShouldBe(100f);
        }
    }
}