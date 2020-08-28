using EasyAbp.Abp.Dynamic.FieldDefinitions;

namespace EasyAbp.Abp.Dynamic.EntityFrameworkCore.FieldDefinitions
{
    public class FieldDefinitionRepositoryTests : DynamicEntityFrameworkCoreTestBase
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
