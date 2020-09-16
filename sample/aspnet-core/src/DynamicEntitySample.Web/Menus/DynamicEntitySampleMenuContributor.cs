using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using DynamicEntitySample.Localization;
using DynamicEntitySample.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace DynamicEntitySample.Web.Menus
{
    public class DynamicEntitySampleMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<DynamicEntitySampleResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(DynamicEntitySampleMenus.Home, l["Menu:Home"], "~/"));
            context.Menu.AddItem(
                new ApplicationMenuItem(DynamicEntitySampleMenus.Computer, l["Menu:Computer"], "/Computers/Computer")
            );
        }
    }
}
