namespace ReviewYourFavourites.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly ReviewYourFavouritesDbContext db;

        public UsersService(ReviewYourFavouritesDbContext db)
        {
            this.db = db;
        }

        public async Task<UserProfileServiceModel> GetInfoAsync(string id)
        => await this.db.Users
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<bool> IsComicAuthorAsync(string userId, int comicId)
        {
            var user = await this.db.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            this.db.Entry(user)
                   .Collection(u => u.Comics)
                   .Load();

            var userComics = user.Comics.Select(c => c.Id).ToList();

            if (userComics == null)
            {
                return false;
            }

            return userComics.Any(x => x == comicId);
        }

        public async Task<int> GetComicsViewsAsync(string id)
        {
            var user = await this.db.Users.FindAsync(id);

            this.db.Entry(user)
                   .Collection(u => u.Comics)
                   .Load();

            return user.Comics.Sum(c => c.Views);
        }

        public async Task<int> GetMoviesViewsAsync(string id)
        {
            var user = await this.db.Users.FindAsync(id);

            this.db.Entry(user)
                   .Collection(u => u.Movies)
                   .Load();

            return user.Movies.Sum(c => c.Views);
        }

        public async Task<int> GetBooksViewsAsync(string id)
        {
            var user = await this.db.Users.FindAsync(id);

            this.db.Entry(user)
                   .Collection(u => u.Books)
                   .Load();

            return user.Books.Sum(c => c.Views);
        }
    }
}
