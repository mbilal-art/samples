using System.Security.Cryptography;

namespace Gateway.Extensions
{
    public class Cryptography
    {
        private const string SymmetricAlgorithm_SECRETKEY = "";
        public static CryptoStream EncryptStream(Stream responseStream)
        {
            Aes aes = GetEncryptionAlgorithm();

            ToBase64Transform base64Transform = new ToBase64Transform();
            CryptoStream base64EncodedStream = new CryptoStream(responseStream, base64Transform, CryptoStreamMode.Write);
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            CryptoStream cryptoStream = new CryptoStream(base64EncodedStream, encryptor, CryptoStreamMode.Write);

            return cryptoStream;
        }

        private static Aes GetEncryptionAlgorithm()
        {
            Aes aes = Aes.Create();
            aes.Key = GenerateRandomBytes(32);
            aes.GenerateIV();

            return aes;
        }

        public static Stream DecryptStream(Stream cipherStream)
        {
            Aes aes = GetEncryptionAlgorithm();

            FromBase64Transform base64Transform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces);
            CryptoStream base64DecodedStream = new CryptoStream(cipherStream, base64Transform, CryptoStreamMode.Read);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            CryptoStream decryptedStream = new CryptoStream(base64DecodedStream, decryptor, CryptoStreamMode.Read);
            return decryptedStream;
        }

        //For decrypt queryparams
        public static string DecryptString(string cipherText)
        {
            Aes aes = GetEncryptionAlgorithm();
            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream memoryStream = new MemoryStream(buffer);
            using ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        private static string GetEncodedRandomString(int length)
        {
            var base64 = Convert.ToBase64String(GenerateRandomBytes(length));
            return base64;
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            var byteArray = new byte[length];
            RandomNumberGenerator.Fill(byteArray);
            return byteArray;
        }

    }
}
