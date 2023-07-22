using Newtonsoft.Json;

namespace TronSharp.Dex.Sunio
{
    public class SunioSmartRouter
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<SunioSmartRouterDTO> Data { get; set; }
    }

    public class SunioSmartRouterDTO
    {
        /// <summary>
        /// Amount of the token to be swapped
        /// </summary>
        [JsonProperty("amountIn")]
        public decimal AmountIn { get; set; }

        /// <summary>
        /// Amount of the token that can be swapped for, calculated by the Smart Router (divided by precision)
        /// </summary>
        [JsonProperty("amountOut")]
        public decimal AmountOut { get; set; }

        /// <summary>
        /// USD price of the entered token
        /// </summary>
        [JsonProperty("inUsd")]
        public decimal InUsd { get; set; }

        /// <summary>
        /// USD price of the token to be swapped for
        /// </summary>
        [JsonProperty("outUsd")]
        public decimal OutUsd { get; set; }

        /// <summary>
        /// Price impact
        /// </summary>
        [JsonProperty("impact")]
        public decimal Impact { get; set; }

        /// <summary>
        /// Transaction fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Addresses of the tokens that the path from fromToken to toToken involves
        /// </summary>
        [JsonProperty("tokens")]
        public List<string> Tokens { get; set; }

        /// <summary>
        /// Symbols of the tokens that the path from fromToken to toToken involves
        /// </summary>
        [JsonProperty("symbols")]
        public List<string> Symbols { get; set; }

        /// <summary>
        /// Transaction fees of the liquidity pools that the path from fromToken to toToken involves (0 is displayed for non-SunSwap V3 pools)
        /// </summary>
        [JsonProperty("poolFees")]
        public List<decimal> PoolFees { get; set; }

        /// <summary>
        /// Versions of the liquidity pools that the path from fromToken to toToken involves
        /// </summary>
        [JsonProperty("poolVersions")]
        public List<string> PoolVersions { get; set; }

        /// <summary>
        /// Amounts of the tokens obtained from each pool along the path from fromToken to toToken
        /// </summary>
        [JsonProperty("stepAmountsOut")]
        public List<decimal> StepAmountsOut { get; set; }
    }
}
