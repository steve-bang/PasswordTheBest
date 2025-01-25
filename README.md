# PasswordTheBest

PasswordTheBest is the best password library for .NET. It provides password validation and password hashing to help you follow the best password practices.

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

### Contributing
Contributions are welcome! Please open an issue or submit a pull request on GitHub.

### License
This project is licensed under the MIT License - see the LICENSE file for details.