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

            if (await context.IsGrantedAsync(DynamicPermissions.FieldDefinition.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(DynamicMenus.FieldDefinition, l["Menu:FieldDefinition"], "/Dynamic/Fields/FieldDefinition")
                );
            }
        }
    }
}
