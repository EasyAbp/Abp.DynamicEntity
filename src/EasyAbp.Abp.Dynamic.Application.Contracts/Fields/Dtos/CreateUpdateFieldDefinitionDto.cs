using System;
using System.ComponentModel;
namespace EasyAbp.Abp.Dynamic.Fields.Dtos
{
    [Serializable]
    public class CreateUpdateFieldDefinitionDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }
    }
}