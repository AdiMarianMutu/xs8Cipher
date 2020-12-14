using System.Security.Cryptography;
using Blake3Core;

public partial class xs8 {
    private const ushort BLOCK_SIZE = 256;
    private const ushort ROUNDS = 4;

    private static Blake3 blake3;
    private static RNGCryptoServiceProvider rng;

    private static byte[][] subKey;
    private static byte[][] subIv;

    public xs8() {
        blake3 = new Blake3();
        rng = new RNGCryptoServiceProvider();
    }

    [System.Diagnostics.DebuggerStepThrough]
    public byte[] Encrypt(byte[] data, byte[] key) {
        return Helper.Encrypt(data, key, Helper.GenerateIV());
    }

    [System.Diagnostics.DebuggerStepThrough]
    public byte[] Encrypt(byte[] data, byte[] key, byte[] iv) {
        if (iv.Length != 32)
            ErrorHandling.Throw(ErrorHandling.ErrorCode.IV_LESS_THAN_256BITS);

        return Helper.Encrypt(data, key, iv);
    }

    [System.Diagnostics.DebuggerStepThrough]
    public byte[] Decrypt(byte[] data, byte[] key) {
        return Helper.Decrypt(data, key);
    }
}
