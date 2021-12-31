using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.DynamicEntities;
using EasyAbp.Abp.DynamicEntity.FieldDefinitions;
using EasyAbp.Abp.DynamicEntity.ModelDefinitions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace DynamicEntitySample.DynamicEntities
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

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var fdPrice = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Price");
            if (fdPrice == null)
            {
                fdPrice = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(), "Price", "Price", FieldDataType.Number));
            }

            var fdCpu = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Cpu");
            if (fdCpu == null)
            {
                fdCpu = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(),  "Cpu", "CPU", FieldDataType.Text));
            }

            var fdRam = await _fieldDefinitionRepository.FindAsync(fd => fd.Name == "Ram");
            if (fdRam == null)
            {
                fdRam = await _fieldDefinitionRepository.InsertAsync(new FieldDefinition(_guidGenerator.Create(),  "Ram", "RAM", FieldDataType.Text));
            }

            var mdComputer = await _modelDefinitionRepository.FindAsync(md => md.Name == "Computer");
            if (mdComputer == null)
            {
                mdComputer = new ModelDefinition(_guidGenerator.Create(),  "Computer", "Computer", "DynamicEntitySample.Computer", new PermissionSetValueObject());
                mdComputer.AddField(fdCpu, 1);
                mdComputer.AddField(fdRam, 2);
                mdComputer.AddField(fdPrice, 3);
                await _modelDefinitionRepository.InsertAsync(mdComputer);
            }

            var deComputer = await _dynamicEntityRepository.FirstOrDefaultAsync(de => de.ModelDefinitionId == mdComputer.Id);
            if (deComputer == null)
            {
                var cpus = new[] {"Intel I3", "Intel I5", "Intel I7", "Intel I9"};
                var rams = new[] {"4GB", "8GB", "16GB", "32GB"};
                var prices = new[] {"999", "1999", "2999", "3999"};
                var rnd = new Random();
                for (int i = 0; i < 3000; i++)
                {
                    var entity = new DynamicEntity(_guidGenerator.Create(), context.TenantId, mdComputer.Id);
                    entity.SetProperty("Cpu", cpus[rnd.Next() % cpus.Length]);
                    entity.SetProperty("Ram", rams[rnd.Next() % rams.Length]);
                    entity.SetProperty("Price", prices[rnd.Next() % prices.Length]);
                    await _dynamicEntityRepository.InsertAsync(entity);
                }
            }
        }
    }
}