# PasswordTheBest - Changelog
All notable changes to this project will be documented in this file.

## [2.0.0]

### ✨ New Features
- **Password Strength Analyzer** (`PasswordStrengthAnalyzer`)
  - 5-tier strength assessment (TooWeak → VeryStrong)
  - Common password pattern detection
  - Crack time estimation
  - Visual strength meter output
  - Seamless integration with `CProperties`
  
- **New Hashing Algorithms**
  - `PasswordHashSHA512` (PBKDF2-SHA512)
  - `PasswordHashSHA1` (PBKDF2-SHA1) *[Legacy]*
  - `PasswordHashMD5` (MD5) *[Legacy - Insecure]*

### 🔧 Improvements
- Unified algorithm configuration interface
- Enhanced XML documentation
- Added code examples for all methods
- Improved NuGet package metadata


## [1.0.0] - Initial Release
### New Features
- Core hashing implementations:
  - `PasswordHash256Salt` (PBKDF2-SHA256)
- Abstract base class `PasswordHasherAbstract`
- Configuration options for:
  - Iteration counts
  - Salt sizes
  - Hash lengths