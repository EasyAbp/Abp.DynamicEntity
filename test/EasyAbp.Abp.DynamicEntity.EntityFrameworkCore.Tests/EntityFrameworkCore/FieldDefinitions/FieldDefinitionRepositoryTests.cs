using EasyAbp.Abp.DynamicEntity.FieldDefinitions;

namespace EasyAbp.Abp.DynamicEntity.EntityFrameworkCore.FieldDefinitions
{
    public class FieldDefinitionRepositoryTests : DynamicEntityEntityFrameworkCoreTestBase
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;

        public FieldDefinitionRepositoryTests()
        {
            _fieldDefinitionRepository = GetRequiredService<IFieldDefinitionRepository>();
        }

        /*[Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }*/
    }
}
