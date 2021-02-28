using System;

namespace SampleGallery.Web.Models
{
    public class Photo
    {
        public uint AlbumId { get; set; }
        public uint Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
        public Uri ThumbnailUrl { get; set; }
    }
}
