using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicEntity
{
    public class ClientDemoService : ITransientDependency
    {
        public Task RunAsync()
        {
            return Task.CompletedTask;
        }
    }
}