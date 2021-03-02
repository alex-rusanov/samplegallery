using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SampleGallery.Web.Interfaces;
using SampleGallery.Web.Models;

namespace SampleGallery.Web.Services
{
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceholderService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("jsonPlaceholder");
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(uint userId)
        {
            return await GetContent<IEnumerable<Post>>($"/users/{userId}/posts");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await GetContent<IEnumerable<User>>("/users");
        }

        public async Task<User> GetUser(uint userId)
        {
            return await GetContent<User>($"/users/{userId}");
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            return await GetContent<IEnumerable<Album>>("/albums");
        }

        public async Task<IEnumerable<Album>> GetAlbums(uint userId)
        {
            return await GetContent<IEnumerable<Album>>($"/users/{userId}/albums");
        }

        public async Task<Album> GetAlbum(uint albumId)
        {
            return await GetContent<Album>($"/albums/{albumId}");
        }

        public async Task<IEnumerable<Photo>> GetPhotos(uint albumId)
        {
            return await GetContent<IEnumerable<Photo>>($"/albums/{albumId}/photos");
        }

        private async Task<T> GetContent<T>(string relativeUrl)
        {
            var response = await _httpClient.GetAsync(relativeUrl);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(
                responseStream,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
