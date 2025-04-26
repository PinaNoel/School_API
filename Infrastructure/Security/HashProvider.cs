using System.Security.Cryptography;
using School_API.App.Interfaces;
using School_API.App.DTO;

namespace School_API.Infrastructure.Security
{
    public class HashProvider : IHashProvider
    {
        private const int _HashSize = 32;
        private const int _SaltSize = 16;


        public byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(_SaltSize);
        }


        public HashResult Hash(byte[] salt, string password)
        {
            if (salt == null) salt = GenerateSalt();

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(_HashSize);

            return new HashResult { Salt = salt, Hash = hash };
        }


        public bool Verify(byte[] salt, byte[] hash, string password)
        {
            HashResult NewHash = Hash(salt, password);
            bool result = Compare(salt, hash, NewHash.Hash);

            return result;
        }


        private bool Compare(byte[] salt, byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) return false;

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i]) return false;
            }

            return true;
        }
    }
}