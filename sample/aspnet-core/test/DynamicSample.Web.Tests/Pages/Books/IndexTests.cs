
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DynamicSample.Pages.Books
{
    public class Index_Tests : DynamicSampleWebTestBase
    {
        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange

            // Act
            var response = await GetResponseAsStringAsync("/Book");

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
