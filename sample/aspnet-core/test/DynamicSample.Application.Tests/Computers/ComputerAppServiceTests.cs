using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DynamicSample.Computers
{
    public class ComputerAppServiceTests : DynamicSampleApplicationTestBase
    {
        private readonly IComputerAppService _computerAppService;

        public ComputerAppServiceTests()
        {
            _computerAppService = GetRequiredService<IComputerAppService>();
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
