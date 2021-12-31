using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicEntity
{
    public class DynamicEntityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IDynamicEntityRepository _dynamicEntityRepository;

        public DynamicEntityDataSeedContributor(
            IFieldDefinitionRepository fieldDefinitionRepository,
            IModelDefinitionRepository modelDefinitionRepository,
            IDynamicEntityRepository dynamicEntityRepository)
        {
            _fieldDefinitionRepository = fieldDefinitionRepository;
            _modelDefinitionRepository = modelDefinitionRepository;
            _dynamicEntityRepository = dynamicEntityRepository;
        }
        
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            /* Instead of returning the Task.CompletedTask, you can insert your test data
             * at this point!
             */
            var fdName = new FieldDefinition(DynamicEntityTestConsts.FieldDefinitionNameId, "name", "Name", FieldDataType.Text);
            await _fieldDefinitionRepository.InsertAsync(fdName);

            var fdPrice = new FieldDefinition(DynamicEntityTestConsts.FieldDefinitionPriceId, "price", "Price", FieldDataType.Number);
            await _fieldDefinitionRepository.InsertAsync(fdPrice);

            var mdBook = new ModelDefinition(DynamicEntityTestConsts.ModelDefinitionBookId, "book", "Book", "DynamicEntity.Book", new PermissionSetValueObject());
            mdBook.AddField(fdPrice.Id, 2);
            mdBook.AddField(fdName.Id, 1);
            await _modelDefinitionRepository.InsertAsync(mdBook);

            var deBook1 = new DynamicEntities.DynamicEntity(DynamicEntityTestConsts.DynamicEntityBook1Id, context.TenantId, mdBook.Id);
            deBook1.SetProperty("name", "Book1");
            deBook1.SetProperty("price", 100.00f);
            await _dynamicEntityRepository.InsertAsync(deBook1);

            var deBook2 = new DynamicEntities.DynamicEntity(DynamicEntityTestConsts.DynamicEntityBook2Id, context.TenantId, mdBook.Id);
            deBook2.SetProperty("name", "Book2");
            deBook2.SetProperty("price", 200.00f);
            await _dynamicEntityRepository.InsertAsync(deBook2);
        }
    }
}