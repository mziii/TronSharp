using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Options;
using TronSharp.Accounts;
using TronSharp.Crypto;
using TronSharp.Protocol;

namespace TronSharp
{
    class WalletClient : IWalletClient
    {
        private readonly IGrpcChannelClient _channelClient;
        private readonly IOptions<TronSharpOptions> _options;

        public WalletClient(IGrpcChannelClient channelClient, IOptions<TronSharpOptions> options)
        {
            _channelClient = channelClient;
            _options = options;
        }

        public Wallet.WalletClient GetProtocol()
        {
            var channel = _channelClient.GetProtocol();
            var wallet = new Wallet.WalletClient(channel);
            return wallet;
        }

        public ITronAccount GenerateAccount()
        {
            var tronKey = TronECKey.GenerateKey(_options.Value.Network);
            return new TronAccount(tronKey);
        }

        public ITronAccount GetAccount(string privateKey)
        {
            return new TronAccount(privateKey, _options.Value.Network);
        }

        public WalletSolidity.WalletSolidityClient GetSolidityProtocol()
        {
            var channel = _channelClient.GetSolidityProtocol();
            var wallet = new WalletSolidity.WalletSolidityClient(channel);

            return wallet;
        }

        public ByteString ParseAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));

            byte[] raw;
            if (address.StartsWith("T"))
            {
                raw = Base58Encoder.DecodeFromBase58Check(address);
            }
            else if (address.StartsWith("41"))
            {
                raw = address.HexToByteArray();
            }
            else if (address.StartsWith("0x"))
            {
                raw = address[2..].HexToByteArray();
            }
            else
            {
                try
                {
                    raw = address.HexToByteArray();
                }
                catch (Exception)
                {
                    throw new ArgumentException($"Invalid address: " + address);
                }
            }
            return ByteString.CopyFrom(raw);
        }

        public Metadata GetHeaders()
        {
            if (!string.IsNullOrEmpty(_options.Value.ProApiKey))
                return new Metadata
                {
                    { "TRON-PRO-API-KEY", _options.Value.ProApiKey }
                };
            else if (!string.IsNullOrEmpty(_options.Value.FreeApiKey))
                return new Metadata
                {
                    { "TRON-FREE-API-KEY", _options.Value.FreeApiKey }
                };
            else return new Metadata { };
        }
    }
}
