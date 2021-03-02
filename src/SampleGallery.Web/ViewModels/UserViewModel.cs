using System.Collections.Generic;
using SampleGallery.Web.Models;

namespace SampleGallery.Web.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
