using System;
using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.DynamicEntities;
using EasyAbp.Abp.Dynamic.FieldDefinitions;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace DynamicSample.DynamicEntities
{
    public class DynamicEntityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IFieldDefinitionRepository _fieldDefinitionRepository;
        private readonly IModelDefinitionRepository _modelDefinitionRepository;
        private readonly IDynamicEntityRepository _dynamicEntityRepository;
        private readonly IGuidGenerator _guidGenerator;

        public DynamicEntityDataSeedContributor(IFieldDefinitionRepository fieldDefinitionRepository, IModelDefinitionRepository modelDefinitionRepository, IGuidGenerator guidGenerator, IDynamicEntityRepository dynamicEntityRepository)
        {
            _fieldDefinitionRepository = fieldDefinitionRepository;
            _modelDefinitionRepository = modelDefinitionRepository;
            _dynamicEntityRepository = dynamicEntityRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var fdPrice = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Price");
            if (fdPrice == null)
            {
                fdPrice = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), "Price", "number"));
            }

            var fdCpu = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "CPU");
            if (fdCpu == null)
            {
                fdCpu = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(),  "CPU", "string"));
            }

            var fdRam = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "RAM");
            if (fdRam == null)
            {
                fdRam = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(),  "RAM", "string"));
            }

            var mdComputer = await _modelDefinitionRepository.FindAsync(md => md.Name == "Computer");
            if (mdComputer == null)
            {
                mdComputer = new ModelDefinition(_guidGenerator.Create(),  "Computer", "DynamicSample.Computer");
                mdComputer.AddField(fdCpu.Id, 1);
                mdComputer.AddField(fdRam.Id, 2);
                mdComputer.AddField(fdPrice.Id, 3);
                await _modelDefinitionRepository.InsertAsync(mdComputer);
            }

            var deComputer = await _dynamicEntityRepository.FindAsync(de => de.ModelDefinitionId == mdComputer.Id);
            if (deComputer == null)
            {
                var cpus = new[] {"Intel I3", "Intel I5", "Intel I7", "Intel I9"};
                var rams = new[] {"4GB", "8GB", "16GB", "32GB"};
                var prices = new[] {"999", "1999", "2999", "3999"};
                var rnd = new Random();
                for (int i = 0; i < 30000; i++)
                {
                    var entity = new DynamicEntity(_guidGenerator.Create()).SetModelDefinition(mdComputer.Id);
                    entity.SetProperty("CPU", cpus[rnd.Next() % cpus.Length]);
                    entity.SetProperty("RAM", rams[rnd.Next() % rams.Length]);
                    entity.SetProperty("Price", prices[rnd.Next() % prices.Length]);
                    await _dynamicEntityRepository.InsertAsync(entity);
                }
            }
        }
    }
}