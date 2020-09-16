using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos;
using EasyAbp.Abp.DynamicEntity.Permissions;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Xunit;
using GetListInput = EasyAbp.Abp.DynamicEntity.ModelDefinitions.Dtos.GetListInput;

namespace EasyAbp.Abp.DynamicEntity.ModelDefinitions
{
    public class ModelDefinitionAppServiceTests : DynamicEntityApplicationTestBase
    {
        private readonly IModelDefinitionAppService _modelDefinitionAppService;
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;

        public ModelDefinitionAppServiceTests()
        {
            _modelDefinitionAppService = GetRequiredService<IModelDefinitionAppService>();
            _modelDefinitionRepository = GetRequiredService<IModelDefinitionRepository>();
            _fieldDefinitionRepository = GetRequiredService<IFieldDefinitionRepository>();
        }

        [Fact]
        public async Task ShouldFilterByName()
        {
            // Arrange

            // Act
            var output = await _modelDefinitionAppService.GetListAsync(new GetListInput
            {
                Filter = "book"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].DisplayName.ShouldBe("Book");
            output.Items[0].Type.ShouldBe("DynamicEntity.Book");
        }

        [Fact]
        public async Task ShouldFilterByType()
        {
            // Arrange

            // Act
            var output = await _modelDefinitionAppService.GetListAsync(new GetListInput
            {
                Filter = "DynamicEntity"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].Name.ShouldBe("book");
            output.Items[0].DisplayName.ShouldBe("Book");
        }


        [Fact]
        public async Task ShouldGetFields()
        {
            // Arrange
            var mdBook = await _modelDefinitionRepository.FindAsync(md => md.Name == "book");

            // Act
            var output = await _modelDefinitionAppService.GetAsync(mdBook.Id);

            // Assert
            output.ShouldNotBeNull();
            output.Fields.Count.ShouldBe(2);
            output.Fields[0].Name.ShouldBe("name");
            output.Fields[1].Name.ShouldBe("price");
        }

        [Fact]
        public async Task ShouldCreateANewModelDefinition()
        {
            // Arrange
            var fdName = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "name");
            var fdPrice = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "price");

            // Act
            var output = await _modelDefinitionAppService.CreateAsync(new CreateUpdateModelDefinitionDto
            {
                Name = "car",
                DisplayName = "Car",
                Type = "DynamicEntity.Car",
                FieldIds = new List<Guid>
                {
                    fdName.Id, fdPrice.Id
                },
            });

            // Assert
            var fdPublishDate = await _modelDefinitionAppService.GetAsync(output.Id);
            fdPublishDate.ShouldNotBeNull();
            fdPublishDate.Id.ShouldBe(output.Id);
            fdPublishDate.Name.ShouldBe("car");
            fdPublishDate.DisplayName.ShouldBe("Car");
            fdPublishDate.Type.ShouldBe("DynamicEntity.Car");
            fdPublishDate.Fields.Count.ShouldBe(2);
            fdPublishDate.Fields[0].Name.ShouldBe("name");
            fdPublishDate.Fields[1].Name.ShouldBe("price");
        }
        
        [Fact]
        public async Task ShouldGetByName()
        {
            // Arrange
            
            // Act
            var output = await _modelDefinitionAppService.GetByName("book");
            
            // Assert
            output.ShouldNotBeNull();
            output.DisplayName.ShouldBe("Book");
            output.Type.ShouldBe("DynamicEntity.Book");
            output.Fields.Count.ShouldBe(2);
        }
                
        [Fact]
        public async Task ShouldCheckDuplicateName_Create()
        {
            // Arrange
            
            // Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => _modelDefinitionAppService.CreateAsync(new CreateUpdateModelDefinitionDto
            {
                Name = "book",
                DisplayName = "Book",
                Type = "DynamicEntity.Book"
            }));
            
            // Assert
            ex.Code.ShouldBe(DynamicEntityErrorCodes.ModelDefinitionAlreadyExists);
        }        
        
        [Fact]
        public async Task ShouldCheckDuplicateName_Update()
        {
            // Arrange
            var id = (await _modelDefinitionRepository.InsertAsync(new ModelDefinition(Guid.NewGuid(), "book2", "Book2", "DynamicEntity.Book2"))).Id;
            
            // Act
            var ex = await Assert.ThrowsAsync<BusinessException>(() => _modelDefinitionAppService.UpdateAsync(id, new CreateUpdateModelDefinitionDto
            {
                Name = "book",
                DisplayName = "Book",
                Type = "DynamicEntity.Book"
            }));
            
            // Assert
            ex.Code.ShouldBe(DynamicEntityErrorCodes.ModelDefinitionAlreadyExists);
        }
    }
}