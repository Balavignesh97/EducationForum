using System.Security.Cryptography;

namespace EducationForum.Helpers
{
    public class EncryptionHelper
    {
        private static readonly byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
        public static string Encrypt(string plainText)
        {
            try
            {
                using var aes = Aes.Create();
                aes.Key = key;
                aes.IV = new byte[16]; // Initialization vector (IV) set to zero for simplicity

                using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                throw;
            }

        }

        public static string Decrypt(string cipherText)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = new byte[16];

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);
            {
                return reader.ReadToEnd();
            }
        }
    }
}
