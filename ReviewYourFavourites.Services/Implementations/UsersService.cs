namespace ReviewYourFavourites.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using ReviewYourFavourites.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly ReviewYourFavouritesDbContext db;

        public UsersService(ReviewYourFavouritesDbContext db)
        {
            this.db = db;
        }

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
    }
}
