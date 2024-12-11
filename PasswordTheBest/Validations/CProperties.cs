

using PasswordTheBest.Constants;

namespace PasswordTheBest.Validations
{
    public class CProperties
    {
        public int Minimum { get; set; } = 6;

        // Flags to enable specific password requirements
        public bool IsAtLeastOneUpperCase { get; set; }
        public bool IsAtLeastLowerUpperCase { get; set; }
        public bool IsAtLeastOneDigit { get; set; }
        public bool IsAtLeastOneSpecialCharacter { get; set; }

        /// <summary>
        /// Method to dynamically build a regex pattern based on the properties
        /// </summary>
        /// <returns></returns>
        public string BuildRegexPattern()
        {
            var patterns = new List<string>();

            if (IsAtLeastOneUpperCase)
            {
                patterns.Add(RegexPattern.AtLeastOneUpperCase);
            }

            if (IsAtLeastLowerUpperCase)
            {
                patterns.Add(RegexPattern.AtLeastLowerUpperCase);
            }

            if (IsAtLeastOneDigit)
            {
                patterns.Add(RegexPattern.AtLeastOneDigit);
            }

            if (IsAtLeastOneSpecialCharacter)
            {
                patterns.Add(RegexPattern.AtLeastOneSpecialCharacter);
            }

            // Add the minimum length constraint.
            patterns.Add(string.Format(RegexPattern.MinLength, Minimum));

            // Combine all the regex components into a single regex pattern
            return string.Join("", patterns);
        }
    }
}
