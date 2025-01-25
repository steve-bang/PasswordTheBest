
using PasswordTheBest.Validations;


namespace PasswordTheBest.Tests.Validations
{
    public class CPasswordValidationTests
    {
        [Fact]
        public void ValidPassword_ShouldValid_WhenPasswordRequireIsLowAndInputLow()
        {
            // Arrange
            string password = "123456";

            CPasswordValidation cPasswordValidation = CPasswordValidation.Create(password, new CProperties
            {
                Minimum = 6
            });

            bool resultExpect = true;

            // Act
            bool resultActual = cPasswordValidation.ValidPassword();


            // Assert
            Assert.Equal(resultExpect, resultActual);
        }

        [Fact]
        public void ValidPassword_ShouldInvalid_WhenPasswordRequireStronggAndInputLow()
        {
            // Arrange
            string password = "123456";

            CPasswordValidation cPasswordValidation = CPasswordValidation.Create(password, new CProperties
            {
                Minimum = 6,
                IsAtLeastOneDigit = true,
                IsAtLeastOneSpecialCharacter = true
            });

            bool resultExpect = false;

            // Act
            bool resultActual = cPasswordValidation.ValidPassword();


            // Assert
            Assert.Equal(resultExpect, resultActual);
        }

        [Fact]
        public void ValidPassword_ShouldVlid_WhenPasswordRequireStronggAndInputLow()
        {
            // Arrange
            string password = "mrstev1p@ssword";

            CPasswordValidation cPasswordValidation = CPasswordValidation.Create(password, new CProperties
            {
                Minimum = 6,
                IsAtLeastOneDigit = true,
                IsAtLeastOneSpecialCharacter = true
            });

            bool resultExpect = true;

            // Act
            bool resultActual = cPasswordValidation.ValidPassword();


            // Assert
            Assert.Equal(resultExpect, resultActual);
        }
    }
}
