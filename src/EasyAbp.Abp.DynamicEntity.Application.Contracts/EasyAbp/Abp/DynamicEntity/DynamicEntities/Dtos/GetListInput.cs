using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto, IDynamicQueryInput
    {
        public Guid? ModelDefinitionId { get; set; }
        
        public string ModelName { get; set; }

        public DynamicQueryGroup FilterGroup { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ModelDefinitionId.HasValue && !ModelName.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult(
                    "ModelDefinitionId and ModelName cannot have values at the same time.",
                    new[] {nameof(ModelDefinitionId), nameof(ModelName)});
            }
            
            if (!ModelDefinitionId.HasValue && ModelName.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult("ModelDefinitionId and ModelName cannot both be empty.",
                    new[] {nameof(ModelDefinitionId), nameof(ModelName)});
            }
        }
    }
}