using System.Threading.Tasks;

namespace DynamicSample.Web.Pages.Computers.Computer
{
    public class IndexModel : DynamicSamplePageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
