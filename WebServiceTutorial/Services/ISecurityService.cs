

using WebServiceTutorial.DAL.Response;

namespace WebServiceTutorial.Services
{
    public interface ISecurityService
    {
        GenericResponse<string> Decrypt(string cipherText);
        GenericResponse<string> Encrypt(string plainText);
        string ComputeHash(string plainText);
    }
}