using TronSharp.Contract;
using TronSharp.Dex.Sunio;

namespace TronSharp
{
    public interface ITronClient
    {
        TronNetwork TronNetwork { get; }
        IGrpcChannelClient GetChannel();
        IWalletClient GetWallet();
        ITransactionClient GetTransaction();
        IContractClient GetTRC20Contract();
        ISunioService GetSunioDex();
    }
}
