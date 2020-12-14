using System;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// An Cipher Key Sized Based Block-bit Chaining (CKSBBC)
/// <para></para>
/// Author : Mutu Adi Marian | v1.0.1 (30.01.18)
/// </summary>
public partial class xs8Cipher {

    #region {ENCRYPT}
    /// <summary>
    /// Encrypts the given plain-bytes 
    /// </summary>
    /// <param name="PlainBytes">Bytes to encrypt</param>
    /// <param name="Password">The password to encrypt the plain-bytes</param>
    /// <param name="Size">The password size (128-bit [16char], 256-bit [32char] or 512-bit [64char])</param>
    /// <returns>Encrypted bytes</returns>
    public static byte[] Encrypt(byte[] PlainBytes, string Password, xs8CipherKey Size) {
        ushort _kSize = (ushort)((ushort)Size / 8);
        byte[] _IV = getRandomIV(_kSize);
        byte[] _password = Encoding.UTF8.GetBytes(Password);
        byte[] _keyStream = getSHA256Hash(Encoding.UTF8.GetBytes(Password + Encoding.UTF8.GetString(_IV)));
        byte[] _hBox =  getSHA256Hash(_keyStream);
        byte[] _plainBytes = getPaddedPlainBytes(PlainBytes, _kSize);
        byte[] _encryptedBytes = new byte[_plainBytes.Length + _IV.Length];

        #region [ENCRYPT PROCESS]
        #region  > Plain-Bytes
        for (uint i = 0; i < _plainBytes.Length; i += _kSize) {
            _hBox = getSHA256Hash(_hBox);
            for (ushort j = 0; j < _kSize; j++) {
                if (i == 0) {
                    _encryptedBytes[j] = (byte)(_plainBytes[j] ^ _IV[j] ^ _hBox[j % _hBox.Length] ^ _keyStream[j % _keyStream.Length]);
                } else {
                    _encryptedBytes[i + j] = (byte)(_plainBytes[i + j] ^ _encryptedBytes[(i - _kSize) + j] ^ _hBox[j % _hBox.Length] ^ _keyStream[j % _keyStream.Length]);
                }
            }
        }
        #endregion
        #region > IV
        for (ushort i = 0; i < _IV.Length; i++) {
            _encryptedBytes[(_encryptedBytes.Length - _kSize) + i] = (byte)((_IV[i] ^ _encryptedBytes[(_encryptedBytes.Length - (_kSize * 2)) + i]) ^ _password[i]);
        }
        #endregion
        _encryptedBytes = getSplitting(_encryptedBytes, _kSize);
        _encryptedBytes = getShift(_encryptedBytes, _encryptedBytes.Length / 2, false);
        #endregion

        return _encryptedBytes;
    }
        #endregion

    #region {DECRYPT}
    /// <summary>
    /// Decrypts the given cipher-bytes 
    /// </summary>
    /// <param name="CipherBytes">Bytes to decrypt</param>
    /// <param name="Password">The password to decrypt the cipher-bytes</param>
    /// /// <param name="Size">The password size (128-bit [16char], 256-bit [32char] or 512-bit [64char])</param>
    /// <returns>Decrypted bytes</returns>
    public static byte[] Decrypt(byte[] CipherBytes, string Password, xs8CipherKey Size) {
        ushort _kSize = (ushort)((ushort)Size / 8);
        byte[] _IV = new byte[_kSize];
        byte[] _password = Encoding.UTF8.GetBytes(Password);
        byte[] _decryptedBytes = new byte[CipherBytes.Length - _IV.Length];
        CipherBytes = getShift(CipherBytes, CipherBytes.Length / 2, true);
        CipherBytes = getSplitting(CipherBytes, _kSize);

        #region [DECRYPT PROCESS]
        #region > IV
        for (ushort i = 0; i < _IV.Length; i++) {
            _IV[i] = (byte)((CipherBytes[(CipherBytes.Length - _IV.Length) + i] ^ CipherBytes[(CipherBytes.Length - (_kSize * 2)) + i]) ^ _password[i]);
        }
        #endregion
        #region  > Cipher-Bytes
        byte[] _keyStream = getSHA256Hash(Encoding.UTF8.GetBytes(Password + Encoding.UTF8.GetString(_IV)));
        byte[] _hBox = getSHA256Hash(_keyStream);
        for (uint i = 0; i < _decryptedBytes.Length; i += _kSize) {
            _hBox = getSHA256Hash(_hBox);
            for (ushort j = 0; j < _kSize; j++) {
                if (i == 0) {
                    _decryptedBytes[j] = (byte)(CipherBytes[j] ^ _IV[j] ^ _hBox[j % _hBox.Length] ^  _keyStream[j % _keyStream.Length]);
                } else {
                    _decryptedBytes[i + j] = (byte)(CipherBytes[i + j] ^ CipherBytes[(i - _kSize) + j] ^ _hBox[j % _hBox.Length] ^ _keyStream[j % _keyStream.Length]);
                }
            }
        }
        #endregion
        _decryptedBytes = getRemovedPlainBytesPadding(_decryptedBytes);
        #endregion
            
        return _decryptedBytes;
    }
    #endregion

    #region [FUNCTIONS]
    #region > private

    #region [SHA256 Hash]
    /// <summary>
    /// Get the hash value of the input bytes
    /// </summary>
    private static byte[] getSHA256Hash(byte[] input) {
        SHA256Managed _getHash = new SHA256Managed();
        return _getHash.ComputeHash(input);
    }
    #endregion

    #region [Padding Plain Bytes]
    /// <summary>
    /// Executes the padding of the Plain-Bytes
    /// </summary>
    private static byte[] getPaddedPlainBytes(byte[] plainBytes, ushort blockSize) {
        byte[] paddedPlainBytes;
        uint fit = 1;
        uint blocks = 0;
        ushort padN;

        for (uint i = 0; i < plainBytes.Length; i += blockSize) { blocks = blockSize * fit; fit++; }
        if (plainBytes.Length < blocks) {
                padN = (ushort)(blocks - plainBytes.Length);
                paddedPlainBytes = new byte[blocks];
            } else {
                padN = (ushort)((blocks - plainBytes.Length) + blockSize);
                paddedPlainBytes = new byte[blocks + blockSize];
            }

            byte[] padN_Attached = new byte[padN.ToString().Length];
            padN_Attached = Encoding.UTF8.GetBytes(padN.ToString());

            Buffer.BlockCopy(plainBytes, 0, paddedPlainBytes, 0, plainBytes.Length);
            for (uint i = (uint)plainBytes.Length; i < paddedPlainBytes.Length; i++) {
                if (i >= paddedPlainBytes.Length - padN.ToString().Length) { paddedPlainBytes[i] = padN_Attached[i % padN_Attached.Length]; }
            }
            
        return paddedPlainBytes;
    }
    #endregion

    #region [Remove Padding Plain Bytes]
    /// <summary>
    /// Remove the padding from the Plain-Bytes
    /// </summary>
    /// <param name="input">Bytes from where needs to remove the padding</param>
    private static byte[] getRemovedPlainBytesPadding(byte[] input) {
        try {
            Array.Resize(ref input, input.Length - Convert.ToUInt16(((char)input[input.Length - 2]).ToString() + ((char)input[input.Length - 1]).ToString()));
        } catch {
            Array.Resize(ref input, input.Length - Convert.ToUInt16(((char)input[input.Length - 1]).ToString()));
        }

        return input;
    }
    #endregion

    #region [Random IV Generator]
    /// <summary>
    /// Generate a new true random IV
    /// </summary>
    private static byte[] getRandomIV(ushort size) {
        var rng = new RNGCryptoServiceProvider();
        byte[] iv = new byte[size];
        rng.GetBytes(iv);

        return iv;
    }
    #endregion

    #region [Shift]
    /// <summary>
    /// Executes a shift to left or right (n) of the bytes into the array
    /// </summary>
    /// <param name="input">Bytes to shift</param>
    /// <param name="pos">Number of positions</param>
    /// <param name="r">Shift to right?</param>
    private static byte[] getShift(byte[] input, int pos, bool r) {
        pos %= input.Length;
        byte[] output = new byte[input.Length];
        
        if (r == true) {
            Buffer.BlockCopy(input, input.Length - pos, output, 0, pos);
            Buffer.BlockCopy(input, 0, output, pos, input.Length - pos);
        } else {
            Buffer.BlockCopy(input, pos, output, 0, input.Length - pos);
            Buffer.BlockCopy(input, 0, output, input.Length - pos, pos);
        }

        return output;
    }
    #endregion

    #region [Splitting]
    /// <summary>
    /// Splits the bytes in a fixed position based on the key size
    /// </summary>
    /// <param name="input">Bytes to be splitted</param>
    private static byte[] getSplitting(byte[] input, ushort kSize) {
        byte[] output = new byte [input.Length];
        int c = (input.Length / (kSize - (kSize % (2 * 8))));

        for (int i = 0; i < (kSize - (kSize % (2 * 8))); i++) {
            Buffer.BlockCopy(input, c * i, output, input.Length - (c * i) - c, c);
        }


        return input;
    }
    #endregion

    #endregion
}
#region > public

#region [Key Size]
/// <summary>
/// Set of valid size keys
/// </summary>
public enum xs8CipherKey {
    Size_128bit = 128,
    Size_256bit = 256,
    Size_512bit = 512
}
#endregion

#endregion
#endregion
