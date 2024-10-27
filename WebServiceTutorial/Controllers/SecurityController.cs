using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceTutorial.Services;

namespace WebServiceTutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public async Task<IActionResult> Encryption(string plainText)
        {
            var response = _securityService.Encrypt(plainText);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Decryption(string cipherText)
        {
            var response = _securityService.Decrypt(cipherText);
            return Ok(response);
        }
    }
}
