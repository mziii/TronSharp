using TronSharp.ABI.Decoders;
using TronSharp.ABI.Encoders;

namespace TronSharp.ABI
{
    public class BytesType : ABIType
    {
        public BytesType() : base("bytes")
        {
            Decoder = new BytesTypeDecoder();
            Encoder = new BytesTypeEncoder();
        }

        public override int FixedSize => -1;
    }
}