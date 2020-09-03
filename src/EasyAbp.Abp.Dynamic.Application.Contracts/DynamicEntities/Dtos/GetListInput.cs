﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.Dynamic.DynamicEntities.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto
    {
        private readonly Regex _regFieldName = new Regex(@"^\w+$", RegexOptions.Compiled);
        public string Filter { get; set; }
        public Dictionary<string, string> FieldFilters { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!FieldFilters.IsNullOrEmpty())
            {
                foreach (var name in FieldFilters.Keys)
                {
                    if (!_regFieldName.IsMatch(name))
                    {
                        yield return new ValidationResult($"InvalidFieldName: {name}", new[] {nameof(FieldFilters)});
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