using System.Collections.Generic;
using System.Threading.Tasks;
using SampleGallery.Web.Models;

namespace SampleGallery.Web.Interfaces
{
    public interface IJsonPlaceholderService
    {
        public Task<IEnumerable<Post>> GetPostsByUserId(uint userId);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(uint userId);
        public Task<IEnumerable<Album>> GetAlbums();
        public Task<IEnumerable<Album>> GetAlbums(uint userId);
        public Task<Album> GetAlbum(uint albumId);
        public Task<IEnumerable<Photo>> GetPhotos(uint albumId);
    }
}
