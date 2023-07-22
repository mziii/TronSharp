using Google.Protobuf;
using Org.BouncyCastle.Crypto.Digests;

namespace TronSharp.Crypto
{
    public class Sha256Sm3Hash
    {
        private const int ThirtyTwo = 32;
        public static int LENGTH = ThirtyTwo; // bytes
        public static Sha256Sm3Hash ZERO_HASH = Wrap(new byte[LENGTH]);

        private readonly byte[] _bytes;

        static Sha256Sm3Hash()
        {
        }

        public Sha256Sm3Hash(byte[] rawHashBytes)
        {
            CheckArgument(rawHashBytes.Length == LENGTH);
            _bytes = rawHashBytes;
        }

        public byte[] GetBytes()
        {
            return _bytes;
        }

        public static Sha256Sm3Hash Wrap(byte[] rawHashBytes)
        {
            return new Sha256Sm3Hash(rawHashBytes);
        }
        public static Sha256Sm3Hash Wrap(ByteString rawHashByteString)
        {
            return Wrap(rawHashByteString.ToByteArray());
        }
        public static Sha256Sm3Hash Create(byte[] contents)
        {
            return Of(contents);
        }
        public static Sha256Sm3Hash Of(byte[] contents)
        {
            return Wrap(Hash(contents));
        }
        public static byte[] Hash(byte[] input)
        {
            return Hash(input, 0, input.Length);
        }
        public static byte[] Hash(byte[] input, int offset, int length)
        {
            var digest = new Sha256Digest();
            digest.BlockUpdate(input, offset, length);
            var output = new byte[digest.GetDigestSize()];
            digest.DoFinal(output, 0);
            return output;

        }
        private static void CheckArgument(bool result)
        {
            if (!result)
            {
                throw new ArgumentException();
            }
        }
    }

}
