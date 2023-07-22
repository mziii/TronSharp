namespace TronSharp.Contract
{
    public interface IContractClientFactory
    {
        IContractClient CreateClient(ContractProtocol protocol);
    }
}
