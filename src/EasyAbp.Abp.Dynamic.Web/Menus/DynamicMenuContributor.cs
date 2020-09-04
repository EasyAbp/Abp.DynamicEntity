using System.Threading.Tasks;
using EasyAbp.Abp.Dynamic.Localization;
using EasyAbp.Abp.Dynamic.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.Dynamic.Web.Menus
{
    public class DynamicMenuContributor : IMenuContributor
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
            var l = context.GetLocalizer<DynamicResource>();
            //Add main menu items.

            if (await context.IsGrantedAsync(DynamicPermissions.FieldDefinition.Default) ||
                await context.IsGrantedAsync(DynamicPermissions.ModelDefinition.Default)
            )
            {
                var menu = new ApplicationMenuItem(DynamicMenus.DynamicManagement, l["Menu:DynamicManagement"]);
                
                if (await context.IsGrantedAsync(DynamicPermissions.FieldDefinition.Default))
                {
                    menu.AddItem(
                        new ApplicationMenuItem(DynamicMenus.FieldDefinition, l["Menu:FieldDefinition"], "/Dynamic/FieldDefinition")
                    );
                }

                if (await context.IsGrantedAsync(DynamicPermissions.ModelDefinition.Default))
                {
                    menu.AddItem(
                        new ApplicationMenuItem(DynamicMenus.ModelDefinition, l["Menu:ModelDefinition"], "/Dynamic/ModelDefinition")
                    );
                }

                context.Menu.AddItem(menu);
            }
        }
    }
}