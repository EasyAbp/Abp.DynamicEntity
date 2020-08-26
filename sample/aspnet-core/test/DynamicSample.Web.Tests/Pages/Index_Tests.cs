using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DynamicSample.Pages
{
    public class Index_Tests : DynamicSampleWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
