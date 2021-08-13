using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using Shouldly;
using Volo.Abp;
using Xunit;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    public class FieldDefinitionAppServiceTests : DynamicEntityApplicationTestBase
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
            output.Items[0].Type.ShouldBe(FieldDataType.Text);
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
                Type = FieldDataType.DateTime,
            });
            
            // Assert
            var fdPublishDate = await _fieldDefinitionRepository.FindAsync(output.Id);
            fdPublishDate.ShouldNotBeNull();
            fdPublishDate.Id.ShouldBe(output.Id);
            fdPublishDate.Name.ShouldBe("publish_date");
            fdPublishDate.DisplayName.ShouldBe("PublishDate");
            fdPublishDate.Type.ShouldBe(FieldDataType.DateTime);
        }

        [Fact]
        public async Task ShouldGetByName()
        {
            // Arrange
            
            // Act
            var output = await _fieldDefinitionAppService.GetByName("name");
            
            // Assert
            output.ShouldNotBeNull();
            output.Type.ShouldBe(FieldDataType.Text);
        }
        
        [Fact]
        public async Task ShouldCheckDuplicateName_Create()
        {
            // Arrange
            
            // Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => _fieldDefinitionAppService.CreateAsync(new CreateUpdateFieldDefinitionDto
            {
                Name = "price",
                DisplayName = "Price",
                Type = FieldDataType.Float
            }));
            
            // Assert
            ex.Code.ShouldBe(DynamicEntityErrorCodes.FieldDefinitionAlreadyExists);
        }        
        
        [Fact]
        public async Task ShouldCheckDuplicateName_Update()
        {
            // Arrange
            var id = (await _fieldDefinitionRepository.GetByNameAsync("name")).Id;
            
            // Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => _fieldDefinitionAppService.UpdateAsync(id, new CreateUpdateFieldDefinitionDto
            {
                Name = "price",
                DisplayName = "Price",
                Type = FieldDataType.Float
            }));
            
            // Assert
            ex.Code.ShouldBe(DynamicEntityErrorCodes.FieldDefinitionAlreadyExists);
        }
    }
}
