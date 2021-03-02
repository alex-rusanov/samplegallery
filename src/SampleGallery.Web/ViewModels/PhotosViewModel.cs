using System.Collections.Generic;
using SampleGallery.Web.Models;

namespace SampleGallery.Web.ViewModels
{
    public class PhotosViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
