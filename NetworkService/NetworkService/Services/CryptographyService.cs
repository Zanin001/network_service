using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace NetworkService.Services
{
    public static class CryptographyService
    {
        private const string Key = "ntwService";
        

        public static string Encrypt(string cleanText)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(cleanText);
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

                using var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(keyBytes);

                using var aesAlg = Aes.Create();
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                using var ms = new MemoryStream();
                var encryptor = aesAlg.CreateEncryptor();
                using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

                cs.Write(bytes, 0, bytes.Length);
                cs.Close();

                cleanText = Convert.ToBase64String(ms.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return cleanText;
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                cipherText = cipherText.Replace(" ", "+");
                byte[] bytes = Encoding.UTF8.GetBytes(cipherText);
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);

                using var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(keyBytes);

                using var aesAlg = Aes.Create();
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                using var ms = new MemoryStream(bytes);
                using var decryptor = aesAlg.CreateDecryptor();
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
                using var ms2 = new MemoryStream();

                cs.CopyTo(ms2);
                cs.Close();

                cipherText = Convert.ToBase64String(ms2.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return cipherText;
        }
    }
}
