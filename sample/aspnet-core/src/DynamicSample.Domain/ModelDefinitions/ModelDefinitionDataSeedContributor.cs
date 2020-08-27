using System.Threading.Tasks;
using DynamicSample.Books;
using DynamicSample.Computers;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace DynamicSample.ModelDefinitions
{
    public class ModelDefinitionDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ModelDefinitionDataSeedContributor(IFieldDefinitionRepository fieldDefinitionRepository, IModelDefinitionRepository modelDefinitionRepository, IGuidGenerator guidGenerator)
        {
            _fieldDefinitionRepository = fieldDefinitionRepository;
            _modelDefinitionRepository = modelDefinitionRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var fdCpu = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "CPU");
            if (fdCpu == null)
            {
                await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), null, "CPU", "string"));
            }

            var fdRam = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "RAM");
            if (fdRam == null)
            {
                await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), null, "RAM", "int"));
            }

            var mdComputer = await _modelDefinitionRepository.FindAsync(md => md.Name == "Computer");
            if (mdComputer == null)
            {
                await _modelDefinitionRepository.InsertAsync(new ModelDefinition(_guidGenerator.Create(), null, "Computer", typeof(Computer).FullName));
            }
            
            var fdPublishDate = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "PublishDate");
            if (fdPublishDate == null)
            {
                await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), null, "PublishDate", "date"));
            }

            var fdPageNumber = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "PageNumber");
            if (fdPageNumber == null)
            {
                await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), null, "PageNumber", "int"));
            }
   
            var mdBook = await _modelDefinitionRepository.FindAsync(md => md.Name == "Book");
            if (mdBook == null)
            {
                await _modelDefinitionRepository.InsertAsync(new ModelDefinition(_guidGenerator.Create(), null, "Book", typeof(Book).FullName));
            }         
        }
    }
}