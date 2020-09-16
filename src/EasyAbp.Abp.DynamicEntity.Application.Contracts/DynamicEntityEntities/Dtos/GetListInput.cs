using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        private readonly Regex _regFieldName = new Regex(@"^\w+$", RegexOptions.Compiled);
        public string Filter { get; set; }
        public List<Filter> FieldFilters { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!FieldFilters.IsNullOrEmpty())
            {
                foreach (var filter in FieldFilters)
                {
                    if (!_regFieldName.IsMatch(filter.FieldName))
                    {
                        yield return new ValidationResult($"InvalidFieldName: {filter.FieldName}", new[] {nameof(FieldFilters)});
                    }
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }
        }
    }
}