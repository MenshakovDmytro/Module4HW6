using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module4HW6.Data;
using Module4HW6.Data.Entity;

namespace Module4HW6.Helper
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly TransactionHelper _transactionHelper;
        private Dictionary<string, Artist> _artists;
        private Dictionary<string, Song> _songs;

        public DbInitializer(ApplicationDbContext context, TransactionHelper transactionHelper)
        {
            _context = context;
            _transactionHelper = transactionHelper;
            _artists = new Dictionary<string, Artist>();
            _songs = new Dictionary<string, Song>();
            Init();
        }

        public async Task InitializeArtistTable()
        {
            await _transactionHelper.ExecuteTransaction(async () =>
            {
                if (!_context.Songs.Any())
                {
                    await _context.Artists.AddAsync(_artists["Eminem"]);
                    await _context.Artists.AddAsync(_artists["Kavinsky"]);
                    await _context.Artists.AddAsync(_artists["Netsky"]);
                    await _context.Artists.AddAsync(_artists["Logic"]);
                    await _context.Artists.AddAsync(_artists["MØ"]);
                    await _context.SaveChangesAsync();
                }
            });
        }

        public async Task InitializeGenreTable()
        {
            await _transactionHelper.ExecuteTransaction(async () =>
            {
                if (!_context.Genres.Any())
                {
                    await _context.Genres.AddAsync(new Genre() { Id = 1, Title = "Rap" });
                    await _context.Genres.AddAsync(new Genre() { Id = 2, Title = "Synthwave" });
                    await _context.Genres.AddAsync(new Genre() { Id = 3, Title = "Liquid Funk" });
                    await _context.Genres.AddAsync(new Genre() { Id = 4, Title = "Drum and Bass" });
                    await _context.Genres.AddAsync(new Genre() { Id = 5, Title = "Indie Pop" });
                    await _context.SaveChangesAsync();
                }
            });
        }

        public async Task InitializeSongTable()
        {
            await _transactionHelper.ExecuteTransaction(async () =>
            {
                if (!_context.Songs.Any())
                {
                    await _context.Songs.AddAsync(_songs["Homicide"]);
                    await _context.Songs.AddAsync(_songs["Love The Way You Lie"]);
                    await _context.Songs.AddAsync(_songs["Secret Agent"]);
                    await _context.Songs.AddAsync(_songs["Slow Love"]);
                    await _context.Songs.AddAsync(_songs["Nightcall"]);
                    await _context.SaveChangesAsync();
                }
            });
        }

        private void Init()
        {
            _artists.Add("Eminem", new Artist() { Id = 1, Name = "Eminem", DateOfBirth = new DateTimeOffset(new DateTime(1972, 10, 17)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/eminem/" });
            _artists.Add("Kavinsky", new Artist() { Id = 2, Name = "Kavinsky", DateOfBirth = new DateTimeOffset(new DateTime(1975, 07, 31)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/kavinsky/" });
            _artists.Add("Netsky", new Artist() { Id = 3, Name = "Netsky", DateOfBirth = new DateTimeOffset(new DateTime(1989, 03, 22)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/netskyofficial/" });
            _artists.Add("Logic", new Artist() { Id = 4, Name = "Logic", DateOfBirth = new DateTimeOffset(new DateTime(1990, 01, 22)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/logic/" });
            _artists.Add("MØ", new Artist() { Id = 5, Name = "MØ", DateOfBirth = new DateTimeOffset(new DateTime(1988, 08, 13)), Phone = null, Email = null, InstagramUrl = "https://www.instagram.com/momomoyouth/" });

            _songs.Add("Homicide", new Song() { Id = 1, Title = "Homicide", Duration = 245, ReleasedDate = new DateTimeOffset(new DateTime(2019, 05, 03)), GenreId = 1 });
            _songs.Add("Love The Way You Lie", new Song() { Id = 2, Title = "Love The Way You Lie", Duration = 255, ReleasedDate = new DateTimeOffset(new DateTime(2010, 06, 18)), GenreId = 1 });
            _songs.Add("Secret Agent", new Song() { Id = 3, Title = "Secret Agent", Duration = 335, ReleasedDate = new DateTimeOffset(new DateTime(2010, 06, 30)), GenreId = 3 });
            _songs.Add("Slow Love", new Song() { Id = 4, Title = "Slow Love", Duration = 217, ReleasedDate = new DateTimeOffset(new DateTime(2014, 03, 06)), GenreId = 5 });
            _songs.Add("Nightcall", new Song() { Id = 5, Title = "Nightcall", Duration = 229, ReleasedDate = new DateTimeOffset(new DateTime(2010, 04, 02)), GenreId = 2 });

            _artists["Eminem"].Songs.Add(_songs["Homicide"]);
            _artists["Eminem"].Songs.Add(_songs["Love The Way You Lie"]);
            _artists["Kavinsky"].Songs.Add(_songs["Nightcall"]);
            _artists["Netsky"].Songs.Add(_songs["Secret Agent"]);
            _artists["Logic"].Songs.Add(_songs["Homicide"]);
            _artists["MØ"].Songs.Add(_songs["Slow Love"]);
        }
    }
}