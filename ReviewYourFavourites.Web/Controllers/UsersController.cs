namespace ReviewYourFavourites.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services;
    using ReviewYourFavourites.Web.Infrastructure.Extensions;
    using ReviewYourFavourites.Web.Models.Users;
    using System.Drawing;
    using System.Threading.Tasks;

    [Authorize]
    public class UsersController : Controller
    {
        private const string ControllerName = "Users";

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

        [HttpPost]
        public async Task<IActionResult> ChangeAvatar(IFormFile avatar, string id)
        {
            if (id != this.userManager.GetUserId(User))
            {
                return BadRequest();
            }

            byte[] fileContents = Image.FromFile(WebConstants.DefaultAvatarPath).ToByteArray();

            if (avatar != null)
            {
                if (!avatar.FileName.EndsWith(WebConstants.JpgExtension)
                    || avatar.Length > DataConstants.UserAvatarFileLength)
                {
                    TempData
                        .AddErrorMessage(WebTextConstants.UserAvatarErrorMessage);
                    return RedirectToAction(nameof(MyProfile),
                    ControllerName,
                    new { id = this.userManager.GetUserId(User) });
                }

                fileContents = await avatar.ToByteArrayAsync();
            }

            await this.usersService.ChangeAvatarAsync(fileContents, id);

            return RedirectToAction(nameof(MyProfile),
                ControllerName,
                new { id = this.userManager.GetUserId(User) });
        }
    }
}
