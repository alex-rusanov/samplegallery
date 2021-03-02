using SampleGallery.Web.Models;

namespace SampleGallery.Web.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public Photo Photo { get; set; }
        public User User { get; set; }
    }
}
