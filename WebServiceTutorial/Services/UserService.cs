using Microsoft.EntityFrameworkCore;
using WebServiceTutorial.DAL.Dtos;
using WebServiceTutorial.DAL.EF;
using WebServiceTutorial.DAL.Models;
using WebServiceTutorial.DAL.Response;
using WebServiceTutorial.Models;

namespace WebServiceTutorial.Services;

public class UserService : IUserService
{
    //Create Sign up/ Register
    //Create Sign in/ Login
    readonly ISecurityService _securityService;
    readonly ApplicationDbContext _db;

    public UserService(ISecurityService securityService, ApplicationDbContext db)
    {
        _securityService = securityService;
        _db = db;
    }

    public async Task<GenericResponse<string>> SignUpAsync(SignUpDto userInformation)
    {
        var response = new GenericResponse<string>();
        string message = "The request is null";
        if (userInformation == null)
        {
            response.Message = message;
            response.Data = message;
            return response;
        }

        //Create database table object and map data

        var now = DateTime.Now;
        var salt = Guid.NewGuid().ToString();
        //userInformation.Password += $"{userInformation.Password}" + $"{salt}";
        userInformation.Password += salt;
        var hashedPassword = _securityService.ComputeHash(userInformation.Password);
        var user = new User
        {
            FirstName = userInformation.FirstName,
            LastName = userInformation.LastName,
            Email = userInformation.Email,
            Tel = userInformation.Tel,
            UserName = userInformation.UserName.ToLower(),
            Password = hashedPassword,
            Salt = salt,
            DateCreated = now,
            DateModified = now
        };


        var dataBaseResponseOnAdd = await _db.Users.AddAsync(user);
        var dataBaseResponseOnSave = await _db.SaveChangesAsync();
        response.IsSuccess = true;
        message = $"Successfully created user with username {userInformation.UserName}";
        response.Message = message;
        response.Data = message;
        return response;
    }
    public async Task<GenericResponse<string>> SignInAsync(SignInDto request)
    {
        var response = new GenericResponse<string>();
        //Challenge
        string message = string.Empty;
        string username = request.UserName.Trim().ToLower();
        var users = _db.Users.ToList();
        var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username);
        user = await _db.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        if (user == null)
        {
            message = $"Username {request.UserName}, does not exist. Please try another valid username";
            response.Message = message;
            return response;
        }

        string userPassword = request.Password;
        userPassword += user.Salt;
        string hashedPassword = _securityService.ComputeHash(userPassword);
        if (user.UserName == username && user.Password == hashedPassword)
        {
            //Then you can write JWT logic to user


            response.IsSuccess = true;
            response.Data = "Enter JWT HERE";
            response.Message = "Successfully logged in";            
        }

        return response;
    }
}
