using System;

public partial class xs8 {
    private static class Helper {
        // The byte attached at the end of the plain data in order to retrieve the start position of the padding data
        private const byte PADDING_END_BYTE = 0x78;

        private static byte[] PadBytes(byte[] input) {
            int inputLen = input.Length;
            int nBlocks = (((inputLen * 8) / BLOCK_SIZE) * BLOCK_SIZE);

            byte[] output = new byte[inputLen + (((BLOCK_SIZE + nBlocks) - (inputLen * 8)) / 8)];

            Array.Copy(input, output, inputLen);
            output[inputLen] = PADDING_END_BYTE;

            return output;
        }

        [System.Diagnostics.DebuggerStepThrough]
        private static byte[] RemovePaddingBytes(byte[] input) {
            int inputLen = input.Length;
            int padBytePos = Array.LastIndexOf(input, PADDING_END_BYTE);

            if (padBytePos == -1)
                ErrorHandling.Throw(ErrorHandling.ErrorCode.PADDING_ENCRYPTED_DATA_CORRUPTED);

            int outputLen = inputLen - (inputLen - padBytePos);

            byte[] output = new byte[outputLen];
            Array.Copy(input, 0, output, 0, outputLen);

            return output;
        }

        public static byte[] GenerateIV(ushort bits = BLOCK_SIZE) {
            byte[] iv = new byte[bits / 8];
            rng.GetBytes(iv);

            return iv;
        }

        public static byte[] Encrypt(byte[] data, byte[] masterKey, byte[] masterIv) {
            subKey = new byte[ROUNDS][];
            subIv = new byte[ROUNDS][];

            byte[] plainDataPadded = PadBytes(data);
            int paddedDataLen = plainDataPadded.Length;

            byte[] encrData = new byte[paddedDataLen + (BLOCK_SIZE / 8)];
            Array.Copy(plainDataPadded, 0, encrData, 0, paddedDataLen);
            Array.Copy(masterIv, 0, encrData, encrData.Length - (BLOCK_SIZE / 8), (BLOCK_SIZE / 8));

            for (int r = 0; r < ROUNDS; r++) {
                subKey[r] = blake3.ComputeHash(r == 0 ? masterKey : subKey[r - 1]);
                subIv[r] = blake3.ComputeHash(r == 0 ? masterIv : subIv[r - 1]);

                encrData = _Encrypt(r, encrData);
            }

            return encrData;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static byte[] Decrypt(byte[] data, byte[] masterKey) {
            subKey = new byte[ROUNDS][];
            subIv = new byte[ROUNDS][];

            int encrDataLen = data.Length - (BLOCK_SIZE / 8);
            byte[] _data = data;
            byte[] _decrData = new byte[encrDataLen];
            byte[] masterIv = new byte[(BLOCK_SIZE / 8)];

            Array.Copy(_data, 0, _decrData, 0, encrDataLen);
            Array.Copy(_data, encrDataLen, masterIv, 0, (BLOCK_SIZE / 8));

            for (int i = 0; i < ROUNDS; ++i) {
                subKey[i] = blake3.ComputeHash(i == 0 ? masterKey : subKey[i - 1]);
                subIv[i] = blake3.ComputeHash(i == 0 ? masterIv : subIv[i - 1]);
            }

            for (int r = ROUNDS - 1; r >= 0; --r) 
                _decrData = _Decrypt(r, _decrData);

            byte[] decrData = RemovePaddingBytes(_decrData);

            return decrData;
        }

        private static byte[] _Encrypt(int r, byte[] plainData) {
            int len = plainData.Length;
            int blockSize = BLOCK_SIZE / 8;
            int halfBlockSize = blockSize / 2;
            byte[] encrData = plainData;

            for (int i = 0; i < len - blockSize; i += blockSize) {
                for (int j = 0; j < halfBlockSize; ++j) {
                    if (i < blockSize) {
                        encrData[i + j] = (byte)((plainData[i + j] ^ subIv[r][j]) ^ subKey[r][j]);
                        encrData[(i + j) + halfBlockSize] = (byte)((plainData[(i + j) + halfBlockSize] ^ subIv[r][halfBlockSize + j]) ^ subKey[r][halfBlockSize + j]);
                    } else {
                        encrData[i + j] = (byte)((plainData[i + j] ^ encrData[(i + j) - blockSize]) ^ subKey[r][j]);
                        encrData[(i + j) + halfBlockSize] = (byte)((plainData[(i + j) + halfBlockSize] ^ encrData[((i - blockSize) + halfBlockSize) + j]) ^ subKey[r][halfBlockSize + j]);
                    }
                }
            }

            return encrData;
        }

        private static byte[] _Decrypt(int r, byte[] encryptedData) {
            int len = encryptedData.Length;
            int blockSize = BLOCK_SIZE / 8;
            byte[] decrData = new byte[len];

            for (int i = 0; i < len; ++i) {
                if (i < blockSize)
                    decrData[i] = (byte)((encryptedData[i] ^ subIv[r][i]) ^ subKey[r][i]);
                else
                    decrData[i] = (byte)((encryptedData[i] ^ encryptedData[i - blockSize]) ^ subKey[r][i % blockSize]);
            }

            return decrData;
        }
    }
}
