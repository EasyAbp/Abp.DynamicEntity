using System.Collections.Generic;
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

        public DynamicEntityAppServiceTests()
        {
            _dynamicEntityAppService = GetRequiredService<IDynamicEntityAppService>();
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