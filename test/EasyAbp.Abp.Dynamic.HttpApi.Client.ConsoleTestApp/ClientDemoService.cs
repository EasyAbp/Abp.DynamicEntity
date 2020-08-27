using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.Dynamic
{
    public class ClientDemoService : ITransientDependency
    {
        public Task RunAsync()
        {
            return Task.CompletedTask;
        }
    }
}