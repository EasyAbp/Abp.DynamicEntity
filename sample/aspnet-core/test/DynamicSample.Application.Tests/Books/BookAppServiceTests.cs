using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DynamicSample.Books
{
    public class BookAppServiceTests : DynamicSampleApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppServiceTests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
