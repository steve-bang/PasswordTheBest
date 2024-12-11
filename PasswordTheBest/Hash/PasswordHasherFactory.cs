using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordTheBest
{
    public abstract class PasswordHasherFactory
    {
        public const string MethodNotImplement = "The method not implement.";

        /// <summary>
        /// The password hashing algorithms
        /// </summary>
        public PasswordHashingAlgorithms Algorithms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public abstract string Hash(string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public abstract string Hash(string password, out string salt);

    }
}
