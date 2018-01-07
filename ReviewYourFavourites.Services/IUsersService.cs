namespace ReviewYourFavourites.Services
{
    using ReviewYourFavourites.Services.Models;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<bool> IsComicAuthorAsync(string userId, int comicId);

        Task<UserProfileServiceModel> GetInfoAsync(string id);

        Task<int> GetComicsViewsAsync(string id);

        Task<int> GetMoviesViewsAsync(string id);

        Task<int> GetBooksViewsAsync(string id);
    }
}
