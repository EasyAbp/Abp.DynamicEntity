namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class Filter
    {
        public string FieldName { get; set; }
        public Operator Operator { get; set; }
        public object Value { get; set; }
    }
}