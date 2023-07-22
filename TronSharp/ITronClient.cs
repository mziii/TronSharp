using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronSharp.Contract;

namespace TronSharp
{
    public interface ITronClient
    {
        TronNetwork TronSharpwork { get; }
        IGrpcChannelClient GetChannel();
        IWalletClient GetWallet();
        ITransactionClient GetTransaction();
        IContractClient GetContract();
    }
}
