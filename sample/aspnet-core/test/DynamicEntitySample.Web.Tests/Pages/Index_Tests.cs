using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DynamicEntitySample.Pages
{
    public class Index_Tests : DynamicEntitySampleWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
