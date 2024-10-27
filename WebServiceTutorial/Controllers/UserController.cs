using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceTutorial.Services;

namespace WebServiceTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IJsonPlaceholderService _jsonPlaceholderService;

        public UserController(IJsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _jsonPlaceholderService.GetJsonPlaceholderAsync();
            if (!users.Any())
            {
                return NotFound("No user was found. Hahahaahaaahahahahhahahaha!!!!");
            }
            return Ok(users);
        }
    }
}
