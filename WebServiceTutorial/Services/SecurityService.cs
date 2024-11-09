using System.Security.Cryptography;
using System.Text;
using WebServiceTutorial.DAL.Response;


namespace WebServiceTutorial.Services;

public class SecurityService : ISecurityService
{
   
    string key = "No key yet oooooooo";
    public SecurityService(IConfiguration configuration)
    {
        key = configuration["Secrets:AesKey"]!;
    }

    //To return Cipher Text
    public GenericResponse<string> Encrypt(string plainText)
    {
        var response = new GenericResponse<string>();
        if (string.IsNullOrEmpty(plainText))
        {
            response.Message = "Text can not be null. Please pass a valid text";
            return response;
        }

        var plainTextBytes = GetBytes(plainText);
        using (var aes = Aes.Create())
        {
            aes.Key = GetBytes(key);
            aes.IV = GetBytes(key);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    var memoryStreamArray = memoryStream.ToArray();
                    var data = Convert.ToBase64String(memoryStreamArray);
                    response.IsSuccess = true;
                    response.Message = "Successfully encrypted the input";
                    response.Data = data;
                    return response;
                }
            }
        }

    }

    //To return Plain Text
    public GenericResponse<string> Decrypt(string cipherText)
    {
        var response = new GenericResponse<string>();
        if (string.IsNullOrEmpty(cipherText))
        {
            response.Message = "Text can not be null. Please pass a valid text";
            return response;
        }

        var cipherTextBytes = Convert.FromBase64String(cipherText);
        using (var aes = Aes.Create())
        {
            aes.Key = GetBytes(key);
            aes.IV = GetBytes(key);

            using (var memoryStream = new MemoryStream(cipherTextBytes))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(cryptoStream))
                    {
                        response.Data = reader.ReadToEnd();
                    }
                }
            }
        }
        response.IsSuccess = true;
        response.Message = "This is the decrypted text";
        return response;
    }

    public string ComputeHash( string plainText)
    {
        var data = SHA256.HashData(GetBytes(plainText));
        var sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    private byte[] GetBytes(string input)
    => System.Text.Encoding.UTF8.GetBytes(input);
}
