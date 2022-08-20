using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicalLayer.Extensions
{
    public static class StringExtensions
    {
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

        public static string StringCleaner(this string info)
        {
            info = info.Replace("R", "").Replace("$", "").Replace(",", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace("-", "");

            return info;
        }
    }
}