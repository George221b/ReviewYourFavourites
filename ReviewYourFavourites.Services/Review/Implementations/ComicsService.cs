﻿namespace ReviewYourFavourites.Services.Review.Implementations
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

        public async Task<List<ListAllReviewsServiceModel>> AllAsync()
            => await this.db
                 .Comics
                 .OrderByDescending(c => c.PublishedOn)
                 .ProjectTo<ListAllReviewsServiceModel>()
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

        public async Task<DetailsComicServiceModel> GetByIdAsync(int id)
            => await this.db.Comics
                    .ProjectTo<DetailsComicServiceModel>()
                    .FirstOrDefaultAsync(c => c.Id.Equals(id));

        public async Task GiveViewAsync(int id)
        {
            var comic = await this.db.Comics.FindAsync(id);
            comic.Views++;

            this.db.Comics.Update(comic);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int comicId,
            string title,
            string content,
            int rating,
            byte[] poster,
            DateTime releaseDate,
            decimal price, 
            string writer)
        {
            var comic = await this.db.Comics.FindAsync(comicId);

            comic.Title = title;
            comic.Content = content;
            comic.Rating = rating;
            comic.Poster = poster;
            comic.ReleaseDate = releaseDate;
            comic.Price = price;
            comic.Writer = writer;
            comic.PublishedOn = DateTime.UtcNow;

            this.db.Comics.Update(comic);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int comicId)
        {
            var comic = this.db.Comics.Find(comicId);

            if (comic == null)
            {
                return false;
            }

            this.db.Comics.Remove(comic);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
