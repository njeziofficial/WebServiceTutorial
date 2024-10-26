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

        // [HttpPost] //C: Create
        [HttpGet] //R: Read
                  // [HttpPut] //U: Update
                  // [HttpDelete] //D: Delete
        public async Task<IActionResult> GetUsers()
        {
            var users = await _jsonPlaceholderService.GetJsonPlaceholderAsync();
            return Ok(users);
        }
    }
}
