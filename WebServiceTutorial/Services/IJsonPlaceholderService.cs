using WebServiceTutorial.Models;

namespace WebServiceTutorial.Services
{
    public interface IJsonPlaceholderService
    {
        Task<IList<ExternalApiUser>> GetJsonPlaceholderAsync();
    }
}