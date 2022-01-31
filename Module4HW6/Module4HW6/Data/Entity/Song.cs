using System;
using System.Collections.Generic;

namespace Module4HW6.Data.Entity
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}