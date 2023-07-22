using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TronSharp.Contract;
using TronSharp.Dex.Sunio;

namespace TronSharp
{
    class TronClient : ITronClient
    {
        private readonly ILogger<TronClient> _logger;
        private readonly IOptions<TronSharpOptions> _options;
        private readonly IGrpcChannelClient _channelClient;
        private readonly IWalletClient _walletClient;
        private readonly ITransactionClient _transactionClient;
        private readonly ISunioService _sunioService;
        private readonly IContractClient _contractClient;
        public TronNetwork TronNetwork => _options.Value.Network;

        public TronClient(ILogger<TronClient> logger, IOptions<TronSharpOptions> options, IGrpcChannelClient channelClient, IWalletClient walletClient, ITransactionClient transactionClient, ISunioService sunioService, IContractClientFactory contractClientFactory)
        {
            _logger = logger;
            _options = options;
            _channelClient = channelClient;
            _walletClient = walletClient;
            _transactionClient = transactionClient;
            _sunioService = sunioService;
            _contractClient = contractClientFactory.CreateClient(ContractProtocol.TRC20);

        }
        public IGrpcChannelClient GetChannel()
        {
            return _channelClient; 
        }
        public IWalletClient GetWallet()
        {
            return _walletClient;
        }

        public ITransactionClient GetTransaction()
        {
            return _transactionClient;
        }

        public IContractClient GetTRC20Contract()
        {
            return _contractClient;
        }

        public ISunioService GetSunioDex()
        {
            return _sunioService;
        }
    }
}
