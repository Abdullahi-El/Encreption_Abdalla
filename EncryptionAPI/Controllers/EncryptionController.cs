using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncryptionController : ControllerBase
    {
        private const int Shift = 3;

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            return Ok(CaesarCipher(text, Shift));
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            return Ok(CaesarCipher(text, -Shift));
        }

        private string CaesarCipher(string text, int shift)
        {
            var result = "";
            foreach (var character in text)
            {
                if (!char.IsLetter(character))
                {
                    result += character;
                    continue;
                }

                var offset = char.IsUpper(character) ? 'A' : 'a';
                result += (char)(((character + shift - offset) % 26) + offset);
            }
            return result;
        }
    }
}