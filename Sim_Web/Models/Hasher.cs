using System.Security.Cryptography;
using System.Text;

namespace Sim_Web.Models
{
    public static class Hasher
    {
        public static string HashData(string data)
        {
            return Hash(Encoding.UTF8.GetBytes(data), "sha256");
        }
        private static string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
            }
        }
    }
}
