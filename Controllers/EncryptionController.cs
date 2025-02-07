using Xunit;
using EncryptionAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI.Tests
{
    public class EncryptionControllerTests
    {
        private readonly EncryptionController _controller;

        public EncryptionControllerTests()
        {
            // Arrange: Initialize the controller
            _controller = new EncryptionController();
        }

        [Fact]
        public void Encrypt_ShouldReturnEncryptedText()
        {
            // Arrange
            var inputText = "hello";

            // Act
            var result = _controller.Encrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("khoor", result.Value);
        }

        [Fact]
        public void Decrypt_ShouldReturnDecryptedText()
        {
            // Arrange
            var inputText = "khoor";

            // Act
            var result = _controller.Decrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("hello", result.Value);
        }

        [Fact]
        public void Encrypt_ShouldHandleNonAlphabeticCharacters()
        {
            // Arrange
            var inputText = "hello123!";

            // Act
            var result = _controller.Encrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("khoor123!", result.Value);
        }

        [Fact]
        public void Decrypt_ShouldHandleNonAlphabeticCharacters()
        {
            // Arrange
            var inputText = "khoor123!";

            // Act
            var result = _controller.Decrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("hello123!", result.Value);
        }

        [Fact]
        public void Encrypt_ShouldHandleEmptyString()
        {
            // Arrange
            var inputText = "";

            // Act
            var result = _controller.Encrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.Value);
        }

        [Fact]
        public void Decrypt_ShouldHandleEmptyString()
        {
            // Arrange
            var inputText = "";

            // Act
            var result = _controller.Decrypt(inputText) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.Value);
        }
    }
}