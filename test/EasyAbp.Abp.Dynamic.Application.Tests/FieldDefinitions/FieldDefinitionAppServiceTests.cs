using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions
{
    public class FieldDefinitionAppServiceTests : DynamicApplicationTestBase
    {
        private readonly IFieldDefinitionAppService _fieldDefinitionAppService;
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;

        public FieldDefinitionAppServiceTests()
        {
            _fieldDefinitionAppService = GetRequiredService<IFieldDefinitionAppService>();
            _fieldDefinitionRepository = GetRequiredService<IFieldDefinitionRepository>();
        }

        [Fact]
        public async Task ShouldCanFilterByName()
        {
            // Arrange

            // Act
            var output = await _fieldDefinitionAppService.GetListAsync(new GetListInput
            {
                Filter = "Name"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].Type.ShouldBe("string");
        }
        
        [Fact]
        public async Task ShouldCanFilterByType()
        {
            // Arrange

            // Act
            var output = await _fieldDefinitionAppService.GetListAsync(new GetListInput
            {
                Filter = "number"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].Name.ShouldBe("Price");
        }
        
        [Fact]
        public async Task ShouldCreateANewFieldDefinition()
        {
            // Arrange
            
            // Act
            var output = await _fieldDefinitionAppService.CreateAsync(new CreateUpdateFieldDefinitionDto
            {
                Name = "PublishDate",
                Type = "date",
            });
            
            // Assert
            var fdPublishDate = await _fieldDefinitionRepository.FindAsync(output.Id);
            fdPublishDate.ShouldNotBeNull();
            fdPublishDate.Id.ShouldBe(output.Id);
            fdPublishDate.Name.ShouldBe("PublishDate");
            fdPublishDate.Type.ShouldBe("date");
        }
    }
}
