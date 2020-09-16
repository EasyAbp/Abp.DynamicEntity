namespace EasyAbp.Abp.DynamicEntity.Web.Menus
{
    public class DynamicEntityMenus
    {
        private const string Prefix = "DynamicEntity";

        //Add your menu items here...
        //public const string Home = Prefix + ".MyNewMenuItem";

        public const string DynamicEntityManagement = Prefix + ".DynamicEntityManagement";
        public const string FieldDefinition = DynamicEntityManagement + ".FieldDefinition";
        public const string ModelDefinition = DynamicEntityManagement + ".ModelDefinition";
    }
}
