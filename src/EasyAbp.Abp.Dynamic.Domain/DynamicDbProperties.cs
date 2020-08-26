namespace EasyAbp.Abp.Dynamic
{
    public static class DynamicDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Dynamic";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Dynamic";
    }
}
