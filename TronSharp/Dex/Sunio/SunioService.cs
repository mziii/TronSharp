using System.Numerics;

namespace TronSharp.Dex.Sunio
{
    public class SunioService : ISunioService
    {
        private readonly ISunioClientFactory _clientFactory;
        public SunioService(ISunioClientFactory clientFactory)
        {

            _clientFactory = clientFactory;
        }

        public async Task<SunioSmartRouter> SmartRouterAsync(string fromTokenAddress, string toTokenAddress, BigInteger amountIn, CancellationToken cancellationToken = default)
        {
            var client = _clientFactory.Create();
            return await client.SmartRouterAsync(fromTokenAddress, toTokenAddress, amountIn, cancellationToken);
        }
    }
}
