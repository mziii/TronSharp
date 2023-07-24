using System.Numerics;
using TronSharp.Accounts;
using TronSharp.Protocol;

namespace TronSharp.Contract
{
    public interface IContractClient
    {
        ContractProtocol Protocol { get; }
        Task<ContractState> GetContractStateAsync(string contractAddress);
        /// <summary>
        /// Calling transfer function of a contract
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAccountPrivateKey">The owner's privatekey</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in decimals</param>
        /// <param name="memo">(Optional) Put a message in the transaction</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <param name="feeLimit">(Optional) If not entered will be calculated</param>
        /// <returns>TxId</returns>
        Task<string> TransferAsync(string contractAddress, string ownerAccountAddress, string ownerAccountPrivateKey, string toAddress, decimal amount, string memo = null, long? contractDecimalPlaces = null, long? feeLimit = null, int energyPrice = 420);

        /// <summary>
        /// Calling transfer function of a contract
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAccount">The owner's TronAccount</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in decimals</param>
        /// <param name="memo">(Optional) Put a message in the transaction</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <param name="feeLimit">(Optional) If not entered will be calculated</param>
        /// <returns>TxId</returns>
        Task<string> TransferAsync(string contractAddress, ITronAccount ownerAccount, string toAddress, decimal amount, string memo = null, long? contractDecimalPlaces = null, long? feeLimit = null, int energyPrice = 420);

        /// <summary>
        /// Calling balanceOf function (Decimal places of contract will be get by calling contract)
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <returns>The balance of the contract for owner's wallet address in decimal</returns>
        Task<decimal> BalanceOfAsync(string contractAddress, string ownerAddress);

        /// <summary>
        /// Calling balanceOf function (Decimal places of contract will be get by calling contract)
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="contractDecimalPlaces">Decimal places of contract</param>
        /// <returns>The balance of the contract for owner's wallet address in decimal</returns>
        Task<decimal> BalanceOfAsync(string contractAddress, string ownerAddress, long contractDecimalPlaces);

        /// <summary>
        /// Calling balanceOf function (Decimal places of contract will be get by calling contract)
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAccount">The owner's TronAccount</param>
        /// <returns>The balance of the contract for owner's wallet in decimal</returns>
        Task<decimal> BalanceOfAsync(string contractAddress, ITronAccount ownerAccount);

        /// <summary>
        /// Calling estimate energy required
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in decimal</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <returns></returns>
        Task<long> EstimateEnergyRequiredAsync(string contractAddress, string ownerAddress, string toAddress, decimal amount, long? contractDecimalPlaces = null);

        /// <summary>
        /// Calling estimate energy required
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in BigInteger</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <returns></returns>
        Task<long> EstimateEnergyRequiredAsync(string contractAddress, string ownerAddress, string toAddress, BigInteger amount);

        /// <summary>
        /// Create token transfer transaction without broadcasting to the network
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in decimal</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <param name="memo">(Optional) Put a message in the transaction</param>
        /// <returns>TransactionExtension object</returns>
        Task<TransactionExtention> CreateTokenTransferTransactionAsync(string contractAddress, string ownerAddress, string toAddress, decimal amount, long? contractDecimalPlaces = null, string memo = null);
        Task<TransactionExtention> CreateTokenTransferTransactionAsync(string contractAddress, string ownerAddress, string toAddress, BigInteger amount, string memo = null);
        Task<long> EstimateFeeLimitByEnergyFactorAsync(string contractAddress, string ownerAddress, string toAddress, BigInteger amount, int energyPrice = 420, string memo = null);

        /// <summary>
        /// Estimate fee limit by using wallet/estimateenergy and multiply by energyprice in SUN
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in decimal</param>
        /// <param name="energyPrice">Currently it's 420 sun by default</param>
        /// <returns>FeeLimit in SUN amount 1,000,000 SUN = 1 TRX</returns>
        Task<long> EstimateFeeLimitAsync(string contractAddress, string ownerAddress, string toAddress, BigInteger amount, int energyPrice = 420);

        /// <summary>
        /// Estimate fee limit by using wallet/estimateenergy and multiply by energyprice in SUN
        /// </summary>
        /// <param name="contractAddress">Contract address</param>
        /// <param name="ownerAddress">The owner's wallet address</param>
        /// <param name="toAddress">The receipt wallet address</param>
        /// <param name="amount">The amount to be transfered in BigInteger</param>
        /// <param name="energyPrice">Currently it's 420 sun by default</param>
        /// <param name="contractDecimalPlaces">(Optional) If not entered will be get by calling contract</param>
        /// <returns>FeeLimit in SUN amount 1,000,000 SUN = 1 TRX</returns>
        Task<long> EstimateFeeLimitAsync(string contractAddress, string ownerAddress, string toAddress, decimal amount, int energyPrice = 420, long? contractDecimalPlaces = null);

        Task<long> GetDecimalsAsync(Wallet.WalletClient walletProtocol, string contractAddress);
        Task<long> GetDecimalsAsync(Wallet.WalletClient walletProtocol, byte[] contractAddressBytes);
        //Task<long> EstimateFeeLimitByMaxFactorAsync(string contractAddress, string ownerAddress, string toAddress, BigInteger amount, string memo = null);
    }
}
