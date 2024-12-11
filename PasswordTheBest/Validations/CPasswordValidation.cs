using System.Text.RegularExpressions;

namespace PasswordTheBest.Validations
{
    public class CPasswordValidation
    {
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The properties password valid.
        /// </summary>
        public CProperties PropertiesValid { get; set; } = new CProperties();

        /// <summary>
        /// Intilize the password.
        /// </summary>
        /// <param name="password"></param>
        public CPasswordValidation(string password) 
        { 
            Password = password;
        }

        /// <summary>
        /// Intilize the password.
        /// </summary>
        /// <param name="password"></param>
        public CPasswordValidation(string password, CProperties properties)
        {
            Password = password;
            PropertiesValid = properties;
        }

        public static CPasswordValidation Create(string password)
        {
            return new CPasswordValidation(password);
        }

        public static CPasswordValidation Create(string password, CProperties properties)
        {
            return new CPasswordValidation(password, properties);
        }

        /// <summary>
        /// Validation with the password input.
        /// </summary>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public bool ValidPassword() 
        {
            string regexPattern = PropertiesValid.BuildRegexPattern();

            return Regex.IsMatch(Password, $"^{regexPattern}$"); 
        }
    }
}
