using Grpc.Core;

namespace TronSharp
{
    public class TronSharpOptions
    {
        public TronNetwork Network { get; set; }
        public GrpcChannelOption Channel { get; set; }

        public GrpcChannelOption SolidityChannel { get; set; }

        public string FreeApiKey { get; set; }
        public string ProApiKey { get; set; }

        internal Metadata GetgRPCHeaders()
        {
            if (!string.IsNullOrEmpty(ProApiKey))
                return new Metadata
                {
                    { "TRON-PRO-API-KEY", ProApiKey }
                };
            else if (!string.IsNullOrEmpty(FreeApiKey))
                return new Metadata
                {
                    { "TRON-FREE-API-KEY", FreeApiKey }
                };
            else return new Metadata { };
        }
    }
}
