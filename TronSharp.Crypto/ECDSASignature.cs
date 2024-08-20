using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;

namespace TronSharp.Crypto
{
    public class ECDSASignature
    {
        private const string InvalidDERSignature = "Invalid DER signature";

        public ECDSASignature(BigInteger r, BigInteger s)
        {
            R = r;
            S = s;
        }

        public ECDSASignature(BigInteger[] rs)
        {
            R = rs[0];
            S = rs[1];
        }

        public ECDSASignature(byte[] derSig)
        {
            try
            {
                using var decoder = new Asn1InputStream(derSig);
                if (decoder.ReadObject() is not DerSequence seq || seq.Count != 2)
                    throw new FormatException(InvalidDERSignature);
                R = ((DerInteger)seq[0]).Value;
                S = ((DerInteger)seq[1]).Value;
            }
            catch (Exception ex)
            {
                throw new FormatException(InvalidDERSignature, ex);
            }
        }

        public BigInteger R { get; }

        public BigInteger S { get; }

        public byte[] V { get; set; }

        public bool IsLowS => S.CompareTo(ECKey.HALF_CURVE_ORDER) <= 0;

        public static ECDSASignature FromDER(byte[] sig)
        {
            return new ECDSASignature(sig);
        }

        public static bool IsValidDER(byte[] bytes)
        {
            try
            {
                FromDER(bytes);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ECDSASignature MakeCanonical()
        {
            if (!IsLowS)
                return new ECDSASignature(R, ECKey.CURVE_ORDER.Subtract(S));
            return this;
        }

        public byte[] ToDER()
        {
            using var bos = new MemoryStream(72);
            var seq = new DerSequenceGenerator(bos);
            seq.AddObject(new DerInteger(R));
            seq.AddObject(new DerInteger(S));
            seq.Dispose(); // Explicitly dispose of the sequence generator.
            return bos.ToArray();
        }

        public byte[] ToByteArray()
        {
            return ByteArrary.Merge(BigIntegerToBytes(R, 32), BigIntegerToBytes(S, 32), this.V);
        }

        private static byte[] BigIntegerToBytes(BigInteger b, int numBytes)
        {
            if (b == null) return null;
            var bytes = new byte[numBytes];
            var biBytes = b.ToByteArray();
            var start = (biBytes.Length == numBytes + 1) ? 1 : 0;
            var length = Math.Min(biBytes.Length, numBytes);
            Array.Copy(biBytes, start, bytes, numBytes - length, length);

            return bytes;
        }
    }
}