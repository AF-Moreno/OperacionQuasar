using MercadoLibre.OperacionQuasar.Core.Utils;
using Xunit;

namespace MercadoLibre.OperacionQasar.Test.Unit.Utils
{
    public class EncryptTest
    {
        [Fact]
        public void GetSHA256_TextToEncrypt_Success()
        {
            // Arrange
            string expectedResult = "69ba267b07f6675629307702ee33127cf1ef8ecb4e836cafd2b81981cf6b023e";
            string textToEncrypt = "secretpwd";

            // Act
            string result = Encrypt.GetSHA256(textToEncrypt);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(result));
            Assert.True(string.Equals(result, expectedResult, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
