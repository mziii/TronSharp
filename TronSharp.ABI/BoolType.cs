using TronSharp.ABI.Decoders;
using TronSharp.ABI.Encoders;

namespace TronSharp.ABI
{
    public class BoolType : ABIType
    {
        public BoolType() : base("bool")
        {
            Decoder = new BoolTypeDecoder();
            Encoder = new BoolTypeEncoder();
        }
    }
}