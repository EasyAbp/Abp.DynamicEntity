using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos;
using EasyAbp.Abp.Dynamic.Permissions;
using Shouldly;
using Volo.Abp.Application.Services;
using Xunit;
using GetListInput = EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos.GetListInput;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions
{
    public class ModelDefinitionAppServiceTests : DynamicApplicationTestBase
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
                Filter = "Book"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].Type.ShouldBe("Dynamic.Book");
        }

        [Fact]
        public async Task ShouldFilterByType()
        {
            // Arrange

            // Act
            var output = await _modelDefinitionAppService.GetListAsync(new GetListInput
            {
                Filter = "Dynamic"
            });

            // Assert
            output.TotalCount.ShouldBe(1);
            output.Items[0].Name.ShouldBe("Book");
        }


        [Fact]
        public async Task ShouldGetFields()
        {
            // Arrange
            var mdBook = await _modelDefinitionRepository.FindAsync(md => md.Name == "Book");

            // Act
            var output = await _modelDefinitionAppService.GetAsync(mdBook.Id);

            // Assert
            output.ShouldNotBeNull();
            output.Fields.Count.ShouldBe(2);
            output.Fields[0].Name.ShouldBe("Name");
            output.Fields[1].Name.ShouldBe("Price");
        }

        [Fact]
        public async Task ShouldCreateANewModelDefinition()
        {
            // Arrange
            var fdName = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Name");
            var fdPrice = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Price");

            // Act
            var output = await _modelDefinitionAppService.CreateAsync(new CreateUpdateModelDefinitionDto
            {
                Name = "Car",
                Type = "Dynamic.Car",
                FieldIds = new List<Guid>
                {
                    fdName.Id, fdPrice.Id
                },
            });

            // Assert
            var fdPublishDate = await _modelDefinitionAppService.GetAsync(output.Id);
            fdPublishDate.ShouldNotBeNull();
            fdPublishDate.Id.ShouldBe(output.Id);
            fdPublishDate.Name.ShouldBe("Car");
            fdPublishDate.Type.ShouldBe("Dynamic.Car");
            fdPublishDate.Fields.Count.ShouldBe(2);
            fdPublishDate.Fields[0].Name.ShouldBe("Name");
            fdPublishDate.Fields[1].Name.ShouldBe("Price");
        }
    }
}