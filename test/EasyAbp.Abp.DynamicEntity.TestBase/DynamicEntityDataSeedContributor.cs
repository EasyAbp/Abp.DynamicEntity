using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace EasyAbp.Abp.DynamicEntity
{
    public class DynamicEntityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityDataSeedContributor(
            IGuidGenerator guidGenerator,
            IFieldDefinitionRepository fieldDefinitionRepository,
            IModelDefinitionRepository modelDefinitionRepository,
            IDynamicEntityRepository dynamicEntityRepository)
        {
            _guidGenerator = guidGenerator;
            _fieldDefinitionRepository = fieldDefinitionRepository;
            _modelDefinitionRepository = modelDefinitionRepository;
            _dynamicEntityRepository = dynamicEntityRepository;
        }
        
        public async Task SeedAsync(DataSeedContext context)
        {
            /* Instead of returning the Task.CompletedTask, you can insert your test data
             * at this point!
             */
            var fdName = new FieldDefinition(_guidGenerator.Create(), "name", "Name", "string");
            await _fieldDefinitionRepository.InsertAsync(fdName);

            var fdPrice = new FieldDefinition(_guidGenerator.Create(), "price", "Price", "number");
            await _fieldDefinitionRepository.InsertAsync(fdPrice);

            var mdBook = new ModelDefinition(_guidGenerator.Create(), "book", "Book", "DynamicEntity.Book");
            mdBook.AddField(fdPrice.Id, 2);
            mdBook.AddField(fdName.Id, 1);
            await _modelDefinitionRepository.InsertAsync(mdBook);

            var deBook1 = new DynamicEntities.DynamicEntity(_guidGenerator.Create());
            deBook1.SetModelDefinition(mdBook.Id);
            deBook1.SetProperty("name", "Book1");
            deBook1.SetProperty("price", 100.00f);
            await _dynamicEntityRepository.InsertAsync(deBook1);           
            
            var deBook2 = new DynamicEntities.DynamicEntity(_guidGenerator.Create());
            deBook2.SetModelDefinition(mdBook.Id);
            deBook2.SetProperty("name", "Book2");
            deBook2.SetProperty("price", 200.00f);
            await _dynamicEntityRepository.InsertAsync(deBook2);
        }
    }
}