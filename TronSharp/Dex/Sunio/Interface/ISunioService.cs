using System.Numerics;

namespace TronSharp.Dex.Sunio
{
    public interface ISunioService
    {
        Task<SunioSmartRouter> SmartRouterAsync(string fromTokenAddress, string toTokenAddress, BigInteger amountIn, CancellationToken cancellationToken = default);
    }
}
