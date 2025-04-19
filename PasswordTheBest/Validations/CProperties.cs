

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
        /// Creates a CProperties instance by analyzing a regex pattern
        /// </summary>
        /// <param name="regexPattern">The regex pattern to analyze</param>
        /// <returns>A configured CProperties instance</returns>
        public static CProperties FromRegexPattern(string regexPattern)
        {
            var properties = new CProperties();

            // Check for minimum length (look for {X,} or {X,Y} pattern)
            var minLengthMatch = System.Text.RegularExpressions.Regex.Match(regexPattern, @"{(\d+),");
            if (minLengthMatch.Success && int.TryParse(minLengthMatch.Groups[1].Value, out int minLength))
            {
                properties.Minimum = minLength;
            }

            // Check for different character requirements
            properties.IsAtLeastOneUpperCase = regexPattern.Contains(@"(?=.*[A-Z])");
            properties.IsAtLeastLowerUpperCase = regexPattern.Contains(@"(?=.*[a-z])") && 
                                               regexPattern.Contains(@"(?=.*[A-Z])");
            properties.IsAtLeastOneDigit = regexPattern.Contains(@"(?=.*\d)");
            properties.IsAtLeastOneSpecialCharacter = regexPattern.Contains(@"(?=.*[\W_])") ||
                                                     regexPattern.Contains(@"(?=.*[!@#$%^&*])");

            return properties;
        }

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
