using System;
using EasyAbp.Abp.Dynamic.ModelDefinitions;
using Volo.Abp.Domain.Entities.Auditing;

namespace DynamicSample.Computers
{
    public class Computer : FullAuditedAggregateRoot<Guid>, IDynamicModel
    {
        /* Some static fields of a computer */

        public virtual ComputerType ComputerType { get; set; }

        public float Price { get; set; }


        /* Dynamic fields */
        public virtual Guid ModelDefinitionId { get; protected set; }

        public virtual ModelDefinition ModelDefinition { get; protected set; }

        protected Computer()
        {
        }

        public Computer(
            Guid id,
            Guid modelDefinitionId
        ) : base(id)
        {
            ModelDefinitionId = modelDefinitionId;
        }
    }
}