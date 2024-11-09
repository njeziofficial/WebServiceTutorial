using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceTutorial.DAL.Dtos;
using WebServiceTutorial.Services;

namespace WebServiceTutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IJsonPlaceholderService _jsonPlaceholderService;
        readonly IUserService _userService;

        public UserController(IJsonPlaceholderService jsonPlaceholderService, IUserService userService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _userService = userService;
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

        [HttpPost]
        public async Task<IActionResult>SignUp(SignUpDto userInformation)
        {
            var response = await _userService.SignUpAsync(userInformation);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto request)
        {
            var response = await _userService.SignInAsync(request);
            return Ok(response);
        }
    }
}
