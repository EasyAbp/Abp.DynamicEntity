using System;
using System.Collections.Generic;

namespace EasyAbp.Abp.Dynamic.ModelDefinitions.Dtos
{
    [Serializable]
    public class CreateUpdateModelDefinitionDto
    {
        public string Name { get; set; }

        public string Type { get; set; }
        
        public List<Guid> FieldIds { get; set; } = new List<Guid>();
    }
}