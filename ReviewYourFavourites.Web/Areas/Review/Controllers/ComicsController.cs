namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services;
    using ReviewYourFavourites.Services.Html;
    using ReviewYourFavourites.Services.Review;
    using ReviewYourFavourites.Web.Areas.Review.Models.Comics;
    using ReviewYourFavourites.Web.Infrastructure.Extensions;
    using System;
    using System.Drawing;
    using System.Threading.Tasks;

    public class ComicsController : BaseReviewController
    {
        private readonly UserManager<User> userManager;
        private readonly IComicsService comicsService;
        private readonly IHtmlService htmlService;
        private readonly IUsersService usersService;

        public ComicsController(
            UserManager<User> userManager,
            IComicsService comicsService,
            IHtmlService htmlService,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.comicsService = comicsService;
            this.htmlService = htmlService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index() //TODO: pagination <-New Old->
        {
            var comics = await this.comicsService.AllAsync();

            return View(comics);
        }

        public IActionResult Create()
        {
            var model = new ComicCreateEditDeleteViewModel()
            {
                ReleaseDate = DateTime.UtcNow,
                Price = 3.99m
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComicCreateEditDeleteViewModel comicModel, IFormFile poster)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            byte[] fileContents;
            try
            {
                fileContents = await ConvertToByteArrayOrThrow(poster);
            }
            catch (Exception)
            {
                TempData.AddErrorMessage(WebTextConstants.ReviewComicPosterErrorMessage);
                return RedirectToAction(nameof(Create));
            }

            var userId = this.userManager.GetUserId(User);
            var content = this.htmlService.Sanitize(comicModel.Content);

            await this.comicsService
                .CreateAsync(userId,
                comicModel.Title,
                content,
                comicModel.Rating,
                fileContents,
                comicModel.ReleaseDate,
                comicModel.Price,
                comicModel.Writer);

            TempData.AddSuccessMessage(WebTextConstants.ReviewComicCreateSuccessMessage);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var comicInfo = await this.comicsService.GetByIdAsync(id);

            var isUserAuthor =
                await this.usersService
                .IsComicAuthorAsync(this.userManager.GetUserId(User), id);

            if (comicInfo == null)
            {
                return NotFound();
            }

            await this.comicsService.GiveViewAsync(id);

            if (User.IsInRole(WebConstants.AdministratorRole))
            {
                isUserAuthor = true;
            }

            return View(new ComicDetailsViewModel()
            {
                Comic = comicInfo,
                IsAuthorOfReview = isUserAuthor
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var isAuthor = await this.usersService.IsComicAuthorAsync(this.userManager.GetUserId(User), id);

            if (!isAuthor && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }

            var comicInfo = await this.comicsService.GetByIdAsync(id);

            return View(new ComicCreateEditDeleteViewModel()
            {
                Title = comicInfo.Title,
                Content = comicInfo.Content,
                ReleaseDate = comicInfo.ReleaseDate,
                Price = comicInfo.Price,
                Rating = comicInfo.Rating,
                Writer = comicInfo.Writer
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ComicCreateEditDeleteViewModel comicModel, IFormFile poster, int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", "Comics", id);
            }

            var userId = this.userManager.GetUserId(User);
            var content = this.htmlService.Sanitize(comicModel.Content);
            var isAuthor = await this.usersService.IsComicAuthorAsync(userId, id);

            if (!isAuthor && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }

            byte[] fileContents;
            try
            {
                fileContents = await ConvertToByteArrayOrThrow(poster);
            }
            catch (ArgumentException)
            {
                TempData.AddErrorMessage(WebTextConstants.ReviewComicPosterErrorMessage);
                return RedirectToAction("Edit", "Comics", id);
            }

            await this.comicsService
                .UpdateAsync(id,
                comicModel.Title,
                content,
                comicModel.Rating,
                fileContents,
                comicModel.ReleaseDate,
                comicModel.Price,
                comicModel.Writer);

            TempData.AddSuccessMessage(WebTextConstants.ReviewComicEditSuccessMessage);

            return RedirectToAction(nameof(Index));
        }

        //TODO: Rework GET Edit&Delete. They share same logic.
        public async Task<IActionResult> Delete(int id) 
        {
            var isAuthor = await this.usersService.IsComicAuthorAsync(this.userManager.GetUserId(User), id);

            if (!isAuthor && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }

            var comicInfo = await this.comicsService.GetByIdAsync(id);

            ViewData["id"] = id;

            return View(new ComicCreateEditDeleteViewModel()
            {
                Title = comicInfo.Title,
                Content = comicInfo.Content,
                ReleaseDate = comicInfo.ReleaseDate,
                Price = comicInfo.Price,
                Rating = comicInfo.Rating,
                Writer = comicInfo.Writer
            });
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var isAuthor = await this.usersService.IsComicAuthorAsync(userId, id);

            if (!isAuthor && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }

            var isDeleted = await this.comicsService.DeleteAsync(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage(WebTextConstants.ReviewComicDeleteSuccessMessage);

            return RedirectToAction(nameof(Index));
        }

        private async Task<byte[]> ConvertToByteArrayOrThrow(IFormFile poster)
        {
            byte[] fileContents = Image.FromFile(WebConstants.DefaultPosterPath).ToByteArray();

            if (poster != null)
            {
                if (!poster.FileName.EndsWith(WebConstants.JpgExtension)
                    || poster.Length > DataConstants.ReviewPosterFileLength)
                {
                    throw new ArgumentException();
                }

                return fileContents = await poster.ToByteArrayAsync();
            }

            return fileContents;
        }
    }
}