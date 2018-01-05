namespace ReviewYourFavourites.Services.Review
{
    using System;
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
    }
}
