using System;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntity : FullAuditedAggregateRoot<Guid>, IMultiTenant, IDynamicModel
    {
        public Guid? TenantId { get; }
        public Guid ModelDefinitionId { get; }
        public ModelDefinition ModelDefinition { get; }
    }
}