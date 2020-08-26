using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
