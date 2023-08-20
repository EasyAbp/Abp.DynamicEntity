using System.Threading.Tasks;
using EasyAbp.Abp.DynamicEntity.Localization;
using EasyAbp.Abp.DynamicEntity.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicEntity.Web.Menus
{
    public class DynamicEntityMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<DynamicEntityResource>();
            //Add main menu items.

            if (await context.IsGrantedAsync(DynamicEntityPermissions.FieldDefinition.Default) ||
                await context.IsGrantedAsync(DynamicEntityPermissions.ModelDefinition.Default)
               )
            {
                var menu = new ApplicationMenuItem(DynamicEntityMenus.DynamicEntityManagement,
                    l["Menu:DynamicEntityManagement"], icon: "fa fa-database");

                if (await context.IsGrantedAsync(DynamicEntityPermissions.FieldDefinition.Default))
                {
                    menu.AddItem(
                        new ApplicationMenuItem(DynamicEntityMenus.FieldDefinition, l["Menu:FieldDefinition"],
                            "/DynamicEntity/FieldDefinition")
                    );
                }

                if (await context.IsGrantedAsync(DynamicEntityPermissions.ModelDefinition.Default))
                {
                    menu.AddItem(
                        new ApplicationMenuItem(DynamicEntityMenus.ModelDefinition, l["Menu:ModelDefinition"],
                            "/DynamicEntity/ModelDefinition")
                    );
                }

                context.Menu.GetAdministration().AddItem(menu);
            }
        }
    }
}