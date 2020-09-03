using System.Threading.Tasks;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.FieldDefinition
{
    public class IndexModel : DynamicPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
