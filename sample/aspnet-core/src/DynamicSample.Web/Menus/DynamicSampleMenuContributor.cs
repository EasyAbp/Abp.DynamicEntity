using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using DynamicSample.Localization;
using DynamicSample.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace DynamicSample.Web.Menus
{
    public class DynamicSampleMenuContributor : IMenuContributor
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

            var l = context.GetLocalizer<DynamicSampleResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("DynamicSample.Home", l["Menu:Home"], "~/"));
            context.Menu.AddItem(
                new ApplicationMenuItem(DynamicSampleMenus.Computer, l["Menu:Computer"], "/Computers/Computer")
            );
        }
    }
}
