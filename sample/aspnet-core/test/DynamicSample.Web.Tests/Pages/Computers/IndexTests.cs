
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DynamicSample.Pages.Computers
{
    public class Index_Tests : DynamicSampleWebTestBase
    {
        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange

            // Act
            var response = await GetResponseAsStringAsync("/Computer");

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
