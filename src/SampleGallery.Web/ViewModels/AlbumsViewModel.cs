using System.Collections.Generic;

namespace SampleGallery.Web.ViewModels
{
    public class AlbumsViewModel
    {
        public IEnumerable<AlbumViewModel> Albums { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
