using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.Abp.Dynamic.Fields
{
    public class FieldDefinitionAppServiceTests : DynamicApplicationTestBase
    {
        private readonly IFieldDefinitionAppService _fieldDefinitionAppService;

        public FieldDefinitionAppServiceTests()
        {
            _fieldDefinitionAppService = GetRequiredService<IFieldDefinitionAppService>();
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
