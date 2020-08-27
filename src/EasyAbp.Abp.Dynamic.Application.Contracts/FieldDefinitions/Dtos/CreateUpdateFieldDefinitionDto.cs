using System;

namespace EasyAbp.Abp.Dynamic.FieldDefinitions.Dtos
{
    [Serializable]
    public class CreateUpdateFieldDefinitionDto
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}