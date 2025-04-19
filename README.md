# PasswordTheBest 🔒

PasswordTheBest is the best password library for .NET. It provides password validation and password hashing to help you follow the best password practices. Advanced password security toolkit with multiple hashing implementations

## 🔐 Supported Algorithms

### ✅ Recommended for Production
| Class                 | Algorithm     | Security  | Ideal For             |
| --------------------- | ------------- | --------- | --------------------- |
| `PasswordHash256Salt` | PBKDF2-SHA256 | High      | Most web applications |
| `PasswordHash512Salt` | PBKDF2-SHA512 | Very High | Financial systems     |

### ⚠️ Legacy Support Only
| Class                  | Algorithm   | Status     | Risk Level             |
| ---------------------- | ----------- | ---------- | ---------------------- |
| `PasswordHashSHA1Salt` | PBKDF2-SHA1 | Deprecated | Critical Security Risk |
| `PasswordHashMD5Salt`  | MD5         | Broken     | Extreme Vulnerability  |

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later

### Installation

You can install the PasswordTheBest library via NuGet Package Manager:

```sh
dotnet add package PasswordTheBest
```

### Usage
#### Password Validation
To validate a password, use the CPasswordValidation class:

``` CSharp
using PasswordTheBest.Validations;

CPasswordValidation cPasswordValidation = CPasswordValidation.Create(password, new CProperties
{
    Minimum = 6,
    IsAtLeastOneDigit = true,
    IsAtLeastOneSpecialCharacter = true
});

    bool resultActual = cPasswordValidation.ValidPassword();
```

#### Password Hashing
Simple for implement:
``` CSharp
using PasswordTheBest;

var password = "password";

var passwordHasher = PasswordTheBestFactory.Create(HashAlgorithmName.SHA256);

var hash = passwordHasher.Hash(password, out string salt);
```

## 🛡️ Password Strength Analysis
```csharp
// Example: Enforce strong passwords
var analyzer = new PasswordStrengthAnalyzer();
if (analyzer.Analyze(userPassword) < PasswordStrength.Strong)
{
    // Require better password
}
```

### Metrics Checked:
- Length (12+ chars recommended)
- Character diversity (upper/lower/numeric/special)
- Common password patterns
- Repeated characters
- Mixed case and special char combinations

## 🔐 Best Practices for Password Security
### 1. Algorithm Selection
+ Recommended: PasswordHash512Salt (PBKDF2-SHA512)
+ Acceptable: PasswordHash256Salt (PBKDF2-SHA256)
- Deprecated: PasswordHashSHA1Salt (Only for legacy systems)
- Forbidden: PasswordHashMD5Salt (Never use in production)

### 2. Configuration Guidelines
| Parameter   | Minimum Value | Recommended Value | Notes                             |
| ----------- | ------------- | ----------------- | --------------------------------- |
| Iterations  | 100,000       | 350,000           | Adjust based on server load       |
| Salt Size   | 16 bytes      | 32 bytes          | Must be cryptographically random  |
| Hash Output | 32 bytes      | 64 bytes          | Longer = more collision-resistant |

### 3. Implementation Checklist
``` CSharp
// ✔️ DO THIS:
var secureHasher = new PasswordHash512Salt(
    hashSize: 64,
    saltSize: 32,
    iterations: 350000
);

// ❌ AVOID THIS:
var weakHasher = new PasswordHashMD5Salt(); // Vulnerable to rainbow tables
```
### 4. Storage Requirements

- Always store:
  - The hash (Base64 encoded)
  - The salt (Base64 encoded)
  - Algorithm version/parameters
- Never store:
  - Plaintext passwords
  - Unsalted hashes
  - Weak algorithm indicators (e.g., "MD5")

## Contributing
Contributions are welcome! Please open an issue or submit a pull request on GitHub.

## License
This project is licensed under the MIT License - see the LICENSE file for details.