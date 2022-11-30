using AdvertApi.Models;
using System.Threading.Tasks;

namespace WebAdvert.AdvertAPI.Services
{
    public interface IAdvertStorageService
    {
        Task<string> Add(AdvertModel model);
        Task<bool> Confirm(ConfirmAdvertModel model);
    }
}
