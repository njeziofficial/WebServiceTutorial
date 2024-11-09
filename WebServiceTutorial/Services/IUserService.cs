using WebServiceTutorial.DAL.Dtos;
using WebServiceTutorial.DAL.Response;

namespace WebServiceTutorial.Services
{
    public interface IUserService
    {
        Task<GenericResponse<string>> SignUpAsync(SignUpDto userInformation);
        Task<GenericResponse<string>> SignInAsync(SignInDto request);
    }
}