using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.Fields;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore.Fields
{
    public class FieldDefinitionRepositoryTests : DynamicEntityFrameworkCoreTestBase
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;

        public FieldDefinitionRepositoryTests()
        {
            _fieldDefinitionRepository = GetRequiredService<IFieldDefinitionRepository>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
