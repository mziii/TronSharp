using Microsoft.Extensions.DependencyInjection;
using Nethereum.RPC.NonceServices;
using Newtonsoft.Json;
using TronSharp.Contract;
using TronSharp.Dex.Sunio;

namespace TronSharp
{
    public static class TronSharpServiceExtension
    {
        public static IServiceCollection AddTronSharp(this IServiceCollection services, Action<TronSharpOptions> setupAction)
        {
            var options = new TronSharpOptions();

            setupAction(options);

            services.AddTransient<ITransactionClient, TransactionClient>();
            services.AddTransient<IGrpcChannelClient, GrpcChannelClient>();
            services.AddTransient<ITronClient, TronClient>();
            services.AddTransient<IWalletClient, WalletClient>();
            services.AddSingleton<IContractClientFactory, ContractClientFactory>();
            services.AddTransient<TRC20ContractClient>();

            #region Binance
            services.AddSingleton<ISunioService, SunioService>();

            services.AddHttpClient<SunioClient>("BinanceClient", x =>
            {
                x.Timeout = TimeSpan.FromSeconds(15);
            });

            services.AddSingleton<ISunioClientFactory, SunioClientFactory>();
            #endregion

            services.AddSingleton(new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            services.Configure(setupAction);

            return services;
        }
    }
}
