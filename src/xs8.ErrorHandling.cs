using System;

public partial class xs8 {
    private static class ErrorHandling {
        public enum ErrorCode {
            IV_LESS_THAN_256BITS = 0,
            PADDING_ENCRYPTED_DATA_CORRUPTED = 1
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static void Throw(ErrorCode c) {
            switch (c) {
                case ErrorCode.IV_LESS_THAN_256BITS:
                    throw new ArgumentException("The IV must be 256 bits long", "Initialization Vector");
                break;
                case ErrorCode.PADDING_ENCRYPTED_DATA_CORRUPTED:
                    throw new ArithmeticException("Unable to unpad: The encrypted data is corrupted");
                break;
            }
        }
    }
}
