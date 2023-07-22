using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<Contracts.IContractClientFactory, Contracts.ContractClientFactory>();
            services.AddTransient<Contracts.TRC20ContractClient>();
            services.Configure(setupAction);

            return services;
        }
    }
}
