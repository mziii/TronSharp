using Microsoft.Extensions.DependencyInjection;

namespace TronSharp.Dex.Sunio
{
    public class SunioClientFactory : ISunioClientFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public SunioClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual SunioClient Create()
        {
            using IServiceScope scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<SunioClient>();
        }
    }
}
