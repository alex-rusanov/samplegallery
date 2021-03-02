using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleGallery.Web.Interfaces;

namespace SampleGallery.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJsonPlaceholderReader _reader;

        public HomeController(IJsonPlaceholderReader reader)
        {
            _reader = reader;
        }

        public async Task<IActionResult> Index(int? page, string albumTitle, string name)
        {
            var response = await _reader.GetAlbumsViewModel(page ?? 1, albumTitle, name);

            return View(response);
        }

        public async Task<IActionResult> Photos(uint id)
        {
            var response = await _reader.GetPhotosViewModel(id);

            return View(response);
        }

        public async Task<IActionResult> User(uint id)
        {
            var response = await _reader.GetUserViewModel(id);

            return View(response);
        }
    }
}
