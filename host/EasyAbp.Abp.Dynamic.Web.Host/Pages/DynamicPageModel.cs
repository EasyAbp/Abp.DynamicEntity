using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Abp.Dynamic.Pages
{
    public abstract class DynamicPageModel : AbpPageModel
    {
        protected DynamicPageModel()
        {
            LocalizationResourceType = typeof(DynamicResource);
        }
    }
}