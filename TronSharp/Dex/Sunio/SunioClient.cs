using Newtonsoft.Json;
using System.Numerics;

namespace TronSharp.Dex.Sunio
{
    public class SunioClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _serializer;
        public SunioClient(HttpClient httpClient, JsonSerializer jsonSerializer)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _serializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
        }

        public async Task<SunioSmartRouter> SmartRouterAsync(string fromTokenAddress, string toTokenAddress, BigInteger amountIn, CancellationToken cancellationToken = default)
        {
            var url = $"https://rot.endjgfsv.link/swap/router?fromToken={fromTokenAddress}&toToken={toTokenAddress}&amountIn={amountIn}";
            var uriBuilder = new UriBuilder(url);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uriBuilder.Uri
            };

            request.Headers.Add("Accept", "application/json");
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

            var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (!result.IsSuccessStatusCode)
            {
                var strResponse = await result.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                throw new Exception(strResponse);
            }

            using var responseStream = await result.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            using var streamReader = new StreamReader(responseStream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            try
            {
                return _serializer.Deserialize<SunioSmartRouter>(jsonTextReader);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
