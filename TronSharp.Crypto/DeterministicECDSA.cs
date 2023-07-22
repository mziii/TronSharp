using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;


namespace TronSharp.Crypto
{
    internal class DeterministicECDSA : ECDsaSigner
    {
        private readonly IDigest _digest;
        private byte[] _buffer = Array.Empty<byte>();

        public DeterministicECDSA()
            : base(new HMacDsaKCalculator(new Sha256Digest()))

        {
            _digest = new Sha256Digest();
        }

        public DeterministicECDSA(Func<IDigest> digest)
            : base(new HMacDsaKCalculator(digest()))
        {
            _digest = digest();
        }


        public void SetPrivateKey(ECPrivateKeyParameters ecKey)
        {
            Init(true, ecKey);
        }

        public byte[] Sign()
        {
            var hash = new byte[_digest.GetDigestSize()];
            _digest.BlockUpdate(_buffer, 0, _buffer.Length);
            _digest.DoFinal(hash, 0);
            _digest.Reset();
            return SignHash(hash);
        }

        public byte[] SignHash(byte[] hash)
        {
            return new ECDSASignature(GenerateSignature(hash)).ToDER();
        }

        public void Update(byte[] buf)
        {
            _buffer = _buffer.Concat(buf).ToArray();
        }
    }

}
