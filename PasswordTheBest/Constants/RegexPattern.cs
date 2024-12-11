using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordTheBest.Constants
{
    public static class RegexPattern
    {
        /// <summary>
        /// Regular expression to ensure at least one uppercase letter is present in a string.
        /// </summary>
        public const string AtLeastOneUpperCase = "(?=.*?[A-Z])";

        /// <summary>
        /// Regular expression to ensure at least one lowercase letter is present in a string.
        /// </summary>
        public const string AtLeastLowerUpperCase = "(?=.*?[a-z])";

        /// <summary>
        /// Regular expression to ensure at least one digit is present in a string.
        /// </summary>
        public const string AtLeastOneDigit = "(?=.*?[0-9])";

        /// <summary>
        /// Regular expression to ensure at least one special character is present in a string.
        /// Special characters include: #, ?, !, @, $, %, ^, &, *, -
        /// </summary>
        public const string AtLeastOneSpecialCharacter = "(?=.*?[#?!@$%^&*-])";

        /// <summary>
        /// Regular expression to specify a minimum length of the given number characters for the string.
        /// Usage: string.Format(MinLength, yourNumberLength);
        /// </summary>
        public const string MinLength = ".{{{0},}}";
    }
}
