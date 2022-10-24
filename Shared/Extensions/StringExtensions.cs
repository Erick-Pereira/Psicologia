using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Shared.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extenção de String, Hasheia uma String usando SHA256
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Retorna uma String hasheada</returns>
        public static string Hash(this string result)
        {
            result = "Q342SSGQQWERTD" + result + "U7RGJ786EFGQ2";
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(result));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Extenção de String, Limpa alguns caracteres de uma String passada
        /// </summary>
        /// <param name="info"></param>
        /// <returns>Retorna uma String</returns>
        public static string StringCleaner(this string info)
        {
            info = info.Replace("R", "").Replace("$", "").Replace(",", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "");

            return info;
        }

        /// <summary>
        /// Extenção de String,Recebe uma chave e encripta uma String Usando Aes
        /// </summary>
        /// <param name="clearText"></param>
        /// <param name="EncryptionKey"></param>
        /// <returns>Retorna um String encriptada</returns>
        public static string Encrypt(this string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// Extenção de String,Recebe uma chave e desencripta uma String Usando Aes
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="EncryptionKey"></param>
        /// <returns>Retorna um String desencriptada</returns>
        public static string Decrypt(this string cipherText, string EncryptionKey)
        {
            cipherText = HttpUtility.UrlDecode(cipherText);
            cipherText = cipherText.Replace(" ", "+").Replace("%2F", "/").Replace("%3D", "=");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}