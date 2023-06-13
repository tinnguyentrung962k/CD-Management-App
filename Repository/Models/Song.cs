using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Duration { get; set; }
        public int AlbumId { get; set; }

        public virtual Cdalbum Album { get; set; }
    }
}
