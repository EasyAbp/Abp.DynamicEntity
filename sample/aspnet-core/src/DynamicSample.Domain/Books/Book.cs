using System;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;

namespace DynamicSample.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>, IDynamicModel
    {
        public virtual string Name { get; set; }
        public virtual string Author { get; set; }
        
        public Guid ModelDefinitionId { get; }
        public ModelDefinition ModelDefinition { get; }
    }
}