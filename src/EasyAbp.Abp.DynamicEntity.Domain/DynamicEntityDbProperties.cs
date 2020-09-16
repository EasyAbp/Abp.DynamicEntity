namespace EasyAbp.Abp.DynamicEntity
{
    public static class DynamicEntityDbProperties
    {
        public static string DbTablePrefix { get; set; } = "DynamicEntity";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "DynamicEntity";
    }
}
