
using System.Security.Cryptography;

namespace PasswordTheBest
{
    public abstract class PasswordHasherAbstract
    {

        /// <summary>
        /// The password hashing algorithms
        /// </summary>
        public HashAlgorithmName Algorithms { get; set; }

        /// <summary>
        /// Hash the password
        /// </summary>
        /// <param name="password">The password</param>
        /// <returns></returns>
        public virtual string Hash(string password) => throw new System.NotImplementedException(nameof(Hash));

        /// <summary>
        /// Hash the password with salt
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="salt">The salt</param>
        /// <returns></returns>
        public virtual string Hash(string password, out string salt) => throw new System.NotImplementedException(nameof(Hash));

        /// <summary>
        /// Verify the password
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="hash">The hash</param>
        /// <param name="salt">The salt</param>
        /// <returns>Returns true if the password is correct</returns>
        public virtual bool Verify(string password, string hash, string salt) => throw new System.NotImplementedException(nameof(Verify));

        /// <summary>
        /// Verify the password
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="hash">The hash</param>
        /// <returns>Returns true if the password is correct</returns>
        public virtual bool Verify(string password, string hash) => throw new System.NotImplementedException(nameof(Verify));

    }
}
