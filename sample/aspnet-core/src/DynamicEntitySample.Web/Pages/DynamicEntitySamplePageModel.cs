using DynamicEntitySample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DynamicEntitySample.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DynamicEntitySamplePageModel : AbpPageModel
    {
        protected DynamicEntitySamplePageModel()
        {
            LocalizationResourceType = typeof(DynamicEntitySampleResource);
        }
    }
}