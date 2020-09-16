using System.Threading.Tasks;

namespace DynamicEntitySample.Web.Pages.Computers.Computer
{
    public class IndexModel : DynamicEntitySamplePageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
