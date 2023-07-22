using System.Numerics;

namespace TronSharp.Contract
{
    public abstract class ContractMessageBase
    {
        public BigInteger AmountToSend { get; set; }
        public BigInteger? Gas { get; set; }
        public BigInteger? GasPrice { get; set; }
        public string FromAddress { get; set; }
        public BigInteger? Nonce { get; set; }
    }

}
