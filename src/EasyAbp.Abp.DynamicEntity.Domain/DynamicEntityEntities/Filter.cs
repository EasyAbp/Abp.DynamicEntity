namespace EasyAbp.Abp.DynamicEntity.DynamicEntityEntities
{
    public class Filter
    {
        public string FieldName { get; set; }
        public Operator Operator { get; set; }
        public object Value { get; set; }
    }
}