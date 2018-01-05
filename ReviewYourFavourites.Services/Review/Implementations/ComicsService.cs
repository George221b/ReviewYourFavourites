namespace ReviewYourFavourites.Services.Review.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services.Review.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ComicsService : IComicsService
    {
        private readonly ReviewYourFavouritesDbContext db;

        public ComicsService(ReviewYourFavouritesDbContext db)
        {
            this.db = db;
        }

        public async Task<List<ListAllComicsServiceModel>> All()
            => await this.db
                 .Comics
                 .OrderByDescending(c => c.PublishedOn)
                 .ProjectTo<ListAllComicsServiceModel>()
                 .ToListAsync();

        public async Task CreateAsync(string userId,
            string title,
            string content,
            int rating,
            byte[] poster,
            DateTime releaseDate,
            decimal price,
            string writer)
        {
            var comic = new Comic()
            {
                AuthorId = userId,
                Title = title,
                Content = content,
                Poster = poster,
                Price = price,
                ReleaseDate = releaseDate,
                Rating = rating,
                Writer = writer,
                PublishedOn = DateTime.UtcNow
            };

            await db.Comics.AddAsync(comic);
            await db.SaveChangesAsync();
        }
    }
}
