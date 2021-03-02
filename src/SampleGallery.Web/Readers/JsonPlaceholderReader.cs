using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleGallery.Web.Interfaces;
using SampleGallery.Web.Models;
using SampleGallery.Web.ViewModels;

namespace SampleGallery.Web.Readers
{
    public class JsonPlaceholderReader : IJsonPlaceholderReader
    {
        private readonly IJsonPlaceholderService _service;

        public JsonPlaceholderReader(IJsonPlaceholderService service)
        {
            _service = service;
        }

        public async Task<AlbumsViewModel> GetAlbumsViewModel(int page, string albumTitle, string name)
        {
            var users = (await _service.GetUsers()).ToList();

            var albumsByName = new List<Album>();

            if (string.IsNullOrEmpty(name))
            {
                albumsByName.AddRange(await _service.GetAlbums());
            }
            else
            {
                if (users.Exists(user => user.Name == name))
                    albumsByName.AddRange(await _service.GetAlbums(users.First(user => user.Name == name).Id));
                else
                    return new AlbumsViewModel();
            }

            var albumsByTitle = string.IsNullOrEmpty(albumTitle)
                ? albumsByName
                : albumsByName.Where(album => album.Title.Contains(albumTitle)).ToList();

            var allViewModels = new List<AlbumViewModel>();

            const int batchSize = 10;

            var numberOfBatches = (int) Math.Ceiling((double) albumsByTitle.Count / batchSize);

            for (var i = 0; i < numberOfBatches; i++)
            {
                var currentAlbums = albumsByTitle.Skip(i * batchSize).Take(batchSize);
                var tasks = currentAlbums.Select(async album =>
                {
                    return new AlbumViewModel
                    {
                        Album = album,
                        Photo = (await _service.GetPhotos(album.Id)).FirstOrDefault(),
                        User = users.FirstOrDefault(user => user.Id == album.UserId)
                    };
                });
                allViewModels.AddRange(await Task.WhenAll(tasks));
            }

            const int pageSize = 12;

            var pageViewModel = new PageViewModel(allViewModels.Count, page, pageSize);

            return new AlbumsViewModel
            {
                PageViewModel = pageViewModel,
                Albums = allViewModels.Skip((page - 1) * pageSize).Take(pageSize)
            };
        }

        public async Task<PhotosViewModel> GetPhotosViewModel(uint albumId)
        {
            return new PhotosViewModel
            {
                Album = await _service.GetAlbum(albumId),
                Photos = await _service.GetPhotos(albumId)
            };
        }

        public async Task<UserViewModel> GetUserViewModel(uint userId)
        {
            return new UserViewModel
            {
                User = await _service.GetUser(userId),
                Posts = await _service.GetPostsByUserId(userId)
            };
        }
    }
}
