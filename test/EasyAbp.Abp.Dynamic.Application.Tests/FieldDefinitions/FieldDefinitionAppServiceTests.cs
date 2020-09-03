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
                Filter = "name"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].DisplayName.ShouldBe("Name");
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
            output.Items[0].Name.ShouldBe("price");
            output.Items[0].DisplayName.ShouldBe("Price");
        }
        
        [Fact]
        public async Task ShouldCreateANewFieldDefinition()
        {
            // Arrange
            
            // Act
            var output = await _fieldDefinitionAppService.CreateAsync(new CreateUpdateFieldDefinitionDto
            {
                Name = "publish_date",
                DisplayName = "PublishDate",
                Type = "date",
            });
            
            // Assert
            var fdPublishDate = await _fieldDefinitionRepository.FindAsync(output.Id);
            fdPublishDate.ShouldNotBeNull();
            fdPublishDate.Id.ShouldBe(output.Id);
            fdPublishDate.Name.ShouldBe("publish_date");
            fdPublishDate.DisplayName.ShouldBe("PublishDate");
            fdPublishDate.Type.ShouldBe("date");
        }

        [Fact]
        public async Task ShouldGetByName()
        {
            // Arrange
            
            // Act
            var output = await _fieldDefinitionAppService.GetByName("name");
            
            // Assert
            output.ShouldNotBeNull();
            output.Type.ShouldBe("string");
        }
    }
}
