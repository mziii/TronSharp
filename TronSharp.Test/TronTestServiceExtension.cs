using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TronSharp.Test
{
    public record TronTestRecord(IServiceProvider ServiceProvider, ITronClient TronClient, IOptions<TronSharpOptions> Options);
    public static class TronTestServiceExtension
    {
        public static IServiceProvider AddTronSharp()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTronSharp(x =>
            {
                x.Network = TronNetwork.MainNet;
                x.Channel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50051 };
                x.SolidityChannel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50052 };
                x.ProApiKey = "1a3caf52-ead8-4080-832c-2fab70549564";
            });
            services.AddLogging();
            return services.BuildServiceProvider();
        }
        public static TronTestRecord GetTestRecord()
        {
            var provider = TronTestServiceExtension.AddTronSharp();
            var client = provider.GetService<ITronClient>();
            var options = provider.GetService<IOptions<TronSharpOptions>>();

            return new TronTestRecord(provider, client, options);
        }
    }
}
