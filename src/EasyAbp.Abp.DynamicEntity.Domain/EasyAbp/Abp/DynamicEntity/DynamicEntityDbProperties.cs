namespace EasyAbp.Abp.DynamicEntity
{
    public static class DynamicEntityDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpAbpDynamicEntity";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpAbpDynamicEntity";
    }
}
