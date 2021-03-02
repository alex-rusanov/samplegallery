using System.Threading.Tasks;
using SampleGallery.Web.ViewModels;

namespace SampleGallery.Web.Interfaces
{
    public interface IJsonPlaceholderReader
    {
        public Task<AlbumsViewModel> GetAlbumsViewModel(int page, string albumTitle, string name);
        public Task<PhotosViewModel> GetPhotosViewModel(uint albumId);
        public Task<UserViewModel> GetUserViewModel(uint userId);
    }
}
