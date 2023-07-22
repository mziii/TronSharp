using TronSharp.ABI.Decoders;
using TronSharp.ABI.Encoders;

namespace TronSharp.ABI
{
    public class StringType : ABIType
    {
        public StringType() : base("string")
        {
            Decoder = new StringTypeDecoder();
            Encoder = new StringTypeEncoder();
        }

        public override int FixedSize => -1;
    }
}