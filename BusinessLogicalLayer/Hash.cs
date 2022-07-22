using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class Hash
    {
        /// <summary>
        /// Recebe uma string contendo uma senha e hasheia ela
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns>Retorna um string hasheada</returns>
        public string ComputeSha256Hash(string rawData)
        {
            rawData = "Q342SSGQQWERTD" + rawData + "U7RGJ786EFGQ2";
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
