using EasyAbp.Abp.DynamicEntity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DynamicEntityPageModel : AbpPageModel
    {
        protected DynamicEntityPageModel()
        {
            LocalizationResourceType = typeof(DynamicEntityResource);
            ObjectMapperContext = typeof(AbpDynamicEntityWebModule);
        }
    }
}