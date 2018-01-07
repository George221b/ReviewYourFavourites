namespace ReviewYourFavourites.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services;
    using ReviewYourFavourites.Web.Models.Users;
    using System.Threading.Tasks;

    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUsersService usersService;

        public UsersController(UserManager<User> userManager,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<IActionResult> MyProfile(string id)
        {
            var currentUserId = this.userManager.GetUserId(User);

            if (id != currentUserId)
            {
                return Unauthorized();
            }

            var userDetails = await this.usersService.GetInfoAsync(id);
            var comicViews = await this.usersService.GetComicsViewsAsync(id);
            var movieViews = await this.usersService.GetMoviesViewsAsync(id);
            var bookViews = await this.usersService.GetBooksViewsAsync(id);

            if (comicViews + movieViews + bookViews >= WebConstants.ViewsNeededForProUserRole)
            {
                await this.usersService.AddToProUserRole(id);
            }

            return View(new UserProfileViewModel()
            {
                UserInfo = userDetails,
                ComicViewsTotal = comicViews,
                MovieViewsTotal = movieViews,
                BookViewsTotal = bookViews
            });
        }

        //POST???
        public async Task<IActionResult> ChangeAvatar(IFormFile avatar)
        {

            return RedirectToAction("MyProfile",
                "Users",
                new { id = this.userManager.GetUserId(User) });
        }
    }
}
