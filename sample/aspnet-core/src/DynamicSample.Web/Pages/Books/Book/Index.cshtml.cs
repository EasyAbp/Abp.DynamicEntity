using System.Threading.Tasks;

namespace DynamicSample.Web.Pages.Books.Book
{
    public class IndexModel : DynamicSamplePageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
