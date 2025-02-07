using Xunit;
using EncryptionAPI.Controllers;

namespace EncryptionAPI.Tests
{
    public class EncryptionControllerTests
    {
        [Fact]
        public void Encrypt_ShouldReturnEncryptedText()
        {
            var controller = new EncryptionController();
            var result = controller.Encrypt("hello");
            Assert.Equal("khoor", result.Value);
        }

        [Fact]
        public void Decrypt_ShouldReturnDecryptedText()
        {
            var controller = new EncryptionController();
            var result = controller.Decrypt("khoor");
            Assert.Equal("hello", result.Value);
        }
    }
}