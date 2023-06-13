using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Cdalbum
    {
        public Cdalbum()
        {
            Songs = new HashSet<Song>();
        }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int ReleaseYear { get; set; }
        public string Author { get; set; }
        public string AlbumGenre { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
