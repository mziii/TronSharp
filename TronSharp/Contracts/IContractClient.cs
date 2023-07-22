using TronSharp.Accounts;
using TronSharp.Protocol;

namespace TronSharp.Contract
{
    public interface IContractClient
    {
        ContractProtocol Protocol { get; }

        Task<string> TransferAsync(string contractAddress, ITronAccount ownerAccount, string toAddress, decimal amount, string memo, long feeLimit);

        Task<decimal> BalanceOfAsync(string contractAddress, string ownerAddress);
        Task<decimal> BalanceOfAsync(string contractAddress, string ownerAddress, long decimalPlaces);
        Task<decimal> BalanceOfAsync(string contractAddress, ITronAccount ownerAccount);

        Task<long> EstimateEnergyRequiredAsync(string contractAddress, string ownerAddress, string toAddress, decimal amount, long decimalPlaces);

        Task<TransactionExtention> CreateTokenTransferTransactionAsync(string contractAddress, string ownerAddress, string toAddress, decimal amount, long decimalPlaces, string memo = null);
    }
}
