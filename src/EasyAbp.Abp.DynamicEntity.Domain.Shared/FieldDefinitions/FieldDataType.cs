using System;

namespace EasyAbp.Abp.DynamicEntity.FieldDefinitions
{
    [Flags]
    public enum FieldDataType
    {
        Text = 1,
        Number = 2,
        Float = 4,
        Boolean = 8,
        DateTime = 16
    }
}