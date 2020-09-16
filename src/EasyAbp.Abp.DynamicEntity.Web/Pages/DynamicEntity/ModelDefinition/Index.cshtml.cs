using System.Threading.Tasks;

namespace EasyAbp.Abp.DynamicEntity.Web.Pages.DynamicEntity.ModelDefinition
{
    public class IndexModel : DynamicEntityPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
