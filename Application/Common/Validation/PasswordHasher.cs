using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Application.Common.Validation
{
    /// <summary>
    /// Provides secure password hashing functionality using Argon2id algorithm
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int DegreeOfParallelism = 1;
        private const int Iterations = 2;
        private const int MemorySize = 19456; // 19 MB

        /// <summary>
        /// Generates a secure hash of a password using Argon2id with a random salt
        /// </summary>
        public static string Hash(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = HashInternal(password, salt);

            var combinedBytes = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, combinedBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, combinedBytes, SaltSize, HashSize);

            return Convert.ToBase64String(combinedBytes);
        }

        /// <summary>
        /// Verifies if a password matches a stored hash
        /// </summary>
        public static bool Verify(string password, string hashedPassword)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (hashedPassword == null)
                throw new ArgumentNullException(nameof(hashedPassword));

            byte[] combinedBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[SaltSize];
            byte[] storedHash = new byte[HashSize];

            Buffer.BlockCopy(combinedBytes, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(combinedBytes, SaltSize, storedHash, 0, HashSize);

            byte[] computedHash = HashInternal(password, salt);

            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }

        /// <summary>
        /// Internal hashing logic using Argon2id
        /// </summary>
        private static byte[] HashInternal(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                Iterations = Iterations,
                MemorySize = MemorySize
            };

            return argon2.GetBytes(HashSize);
        }
    }
}
