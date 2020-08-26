using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.Abp.Dynamic.Pages
{
    public class IndexModel : DynamicPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}