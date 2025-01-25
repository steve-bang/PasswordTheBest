
using System.Security.Cryptography;

namespace PasswordTheBest.Tests.PasswordHash;

public class CPasswordHash256Tests
{
    [Fact]
    public void TestHash()
    {
        // Arrange
        var password = "password";
        //var passwordHash = "passwordHash";
        // Act

        var passwordHasher = PasswordTheBestFactory.Create(HashAlgorithmName.SHA256);

        var hash = passwordHasher.Hash(password, out string salt);

        // Assert
        Assert.NotNull(salt);
        Assert.NotEmpty(salt);
        Assert.True(hash.Length > 0);
    }

    [Fact]
    public void TestVerify()
    {
        // Arrange
        var password = "password";
        var passwordHasher = PasswordTheBestFactory.Create(HashAlgorithmName.SHA256);
        var hash = passwordHasher.Hash(password, out string salt);

        // Act
        var result = passwordHasher.Verify(password, hash, salt);

        // Assert
        Assert.True(result);
    }
}