﻿using System.Collections.Generic;

namespace Module4HW6.Data.Entity
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}