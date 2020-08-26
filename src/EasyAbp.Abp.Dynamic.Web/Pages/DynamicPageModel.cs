using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Abp.Dynamic.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DynamicPageModel : AbpPageModel
    {
        protected DynamicPageModel()
        {
            LocalizationResourceType = typeof(DynamicResource);
            ObjectMapperContext = typeof(DynamicWebModule);
        }
    }
}