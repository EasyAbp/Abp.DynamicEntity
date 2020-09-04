using System.Threading.Tasks;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.ModelDefinition
{
    public class IndexModel : DynamicPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
