using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace DynamicSample.ModelDefinitions
{
    public class FieldDefinitionDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        private readonly IGuidGenerator _guidGenerator;

        public FieldDefinitionDataSeedContributor(IFieldDefinitionRepository fieldDefinitionRepository, IGuidGenerator guidGenerator)
        {
            _fieldDefinitionRepository = fieldDefinitionRepository;
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
        }
    }
}