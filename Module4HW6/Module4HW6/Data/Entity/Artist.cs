using System;
using System.Collections.Generic;

namespace Module4HW6.Data.Entity
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

#nullable enable
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }
#nullable disable
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}