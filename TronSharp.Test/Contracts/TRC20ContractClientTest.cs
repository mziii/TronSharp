using Microsoft.Extensions.DependencyInjection;
using System.Numerics;

namespace TronSharp.Test.Contracts
{
    public class TRC20ContractClientTest
    {
        private TronTestRecord _record;
        private ITronClient _tronClient;
        public TRC20ContractClientTest()
        {
            _record = TronTestServiceExtension.GetTestRecord();
            _tronClient = _record.ServiceProvider.GetService<ITronClient>();
        }

        [Fact]
        public async Task TestEstimateEnergyRequired()
        {
            var contractClient = _tronClient.GetTRC20Contract();
            var usdtContractAddress = "TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t";
            var ownerAddress = "TWS1onJnNTg8tJHomceqxBxTsUB1DHh7PV";
            var toAddress = "TNDTGoJ3dDvEmNHPCit9UUJVqFswaY7yvC";
            var amount = new BigInteger(100) * 1_000_000L;
            var estimateFeeLimitMaxFactor = await contractClient.EstimateFeeLimitByEnergyFactorAsync(usdtContractAddress, ownerAddress, toAddress, amount);
            //var estimateEnergy = await contractClient.EstimateEnergyRequiredAsync(usdtContractAddress, ownerAddress, toAddress, amount);
            //var estimateFeeLimit = await contractClient.EstimateFeeLimitAsync(usdtContractAddress, ownerAddress, toAddress, amount);
        }
    }
}
