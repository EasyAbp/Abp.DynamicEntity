namespace EasyAbp.Abp.Dynamic.Web.Menus
{
    public class DynamicMenus
    {
        private const string Prefix = "Dynamic";

        //Add your menu items here...
        //public const string Home = Prefix + ".MyNewMenuItem";

        public const string DynamicManagement = Prefix + ".DynamicManagement";
        public const string FieldDefinition = DynamicManagement + ".FieldDefinition";
        public const string ModelDefinition = DynamicManagement + ".ModelDefinition";
    }
}
