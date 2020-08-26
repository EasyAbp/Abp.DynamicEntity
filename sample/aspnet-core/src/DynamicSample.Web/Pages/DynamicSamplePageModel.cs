using DynamicSample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DynamicSample.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DynamicSamplePageModel : AbpPageModel
    {
        protected DynamicSamplePageModel()
        {
            LocalizationResourceType = typeof(DynamicSampleResource);
        }
    }
}