using System.Numerics;
using TronSharp.ABI.FunctionEncoding.Attributes;
using TronSharp.Contracts;

namespace TronSharp.Dex.Sunio.V1.Functions
{
    [Function("trxToTokenSwapInput", "uint256")]
    public class TrxToTokenSwapInputFunction : FunctionMessage
    {
        [Parameter("uint256", "min_tokens", 1)]
        public BigInteger MinTokens { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [Parameter("uint256", "deadline", 2)]
        public BigInteger Deadline { get; set; }
    }
}
