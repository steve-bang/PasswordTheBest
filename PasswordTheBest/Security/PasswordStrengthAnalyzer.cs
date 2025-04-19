using System.Text.RegularExpressions;

namespace PasswordTheBest.Security
{
    public class PasswordStrengthAnalyzer
    {
        public enum PasswordStrength
        {
            TooWeak,    // Score 0-1
            Weak,       // Score 2-3
            Moderate,   // Score 4-5
            Strong,     // Score 6-7
            VeryStrong  // Score 8+
        }

        public PasswordStrength Analyze(string password)
        {
            int score = 0;

            // Length check
            if (password.Length >= 12) score += 2;
            else if (password.Length >= 8) score += 1;

            // Complexity checks
            if (Regex.IsMatch(password, @"[A-Z]")) score += 1; // Uppercase
            if (Regex.IsMatch(password, @"[a-z]")) score += 1; // Lowercase
            if (Regex.IsMatch(password, @"[0-9]")) score += 1; // Numbers
            if (Regex.IsMatch(password, @"[\W_]")) score += 2; // Special chars

            // Bonus for mixed case and numbers
            if (Regex.IsMatch(password, @"(?=.*[A-Z])(?=.*[a-z])")) score += 1;
            if (Regex.IsMatch(password, @"(?=.*\d)(?=.*[\W_])")) score += 1;

            // Penalty for common patterns
            if (IsCommonPassword(password)) score = 0;
            if (HasRepeatingChars(password)) score -= 2;

            return score switch
            {
                <= 1 => PasswordStrength.TooWeak,
                <= 3 => PasswordStrength.Weak,
                <= 5 => PasswordStrength.Moderate,
                <= 7 => PasswordStrength.Strong,
                _ => PasswordStrength.VeryStrong
            };
        }

        private bool IsCommonPassword(string password)
        {
            // Load from embedded resource or external file
            var commonPasswords = new HashSet<string>
            {
                "password", "123456", "qwerty", "letmein" // Add more
            };
            return commonPasswords.Contains(password.ToLower());
        }

        private bool HasRepeatingChars(string password)
        {
            return Regex.IsMatch(password, @"(.)\1{3,}"); // 4+ repeating chars
        }

        public string GetStrengthDescription(PasswordStrength strength)
        {
            return strength switch
            {
                PasswordStrength.TooWeak => "Unacceptable (immediately change)",
                PasswordStrength.Weak => "Vulnerable to brute force",
                PasswordStrength.Moderate => "Adequate for low-risk systems",
                PasswordStrength.Strong => "Suitable for most purposes",
                PasswordStrength.VeryStrong => "Excellent protection",
                _ => "Unknown strength"
            };
        }

    }
}