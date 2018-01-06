namespace ReviewYourFavourites.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<bool> IsComicAuthorAsync(string userId, int comicId);
    }
}
