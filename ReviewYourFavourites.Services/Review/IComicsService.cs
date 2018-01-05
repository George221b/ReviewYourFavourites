namespace ReviewYourFavourites.Services.Review
{
    using ReviewYourFavourites.Services.Review.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IComicsService
    {
        Task CreateAsync(string userId,
            string title,
            string content,
            int rating,
            byte[] poster,
            DateTime releaseDate,
            decimal price,
            string writer);

        Task<List<ListAllComicsServiceModel>> All();
    }
}
