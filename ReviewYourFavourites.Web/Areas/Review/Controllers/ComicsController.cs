namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Web.Areas.Review.Models.Comics;
    using System.Threading.Tasks;
    using System;
    using Microsoft.AspNetCore.Http;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services.Review;
    using ReviewYourFavourites.Services.Html;

    public class ComicsController : BaseReviewController
    {
        private readonly UserManager<User> userManager;
        private readonly IComicsService comicsService;
        private readonly IHtmlService htmlService;

        public ComicsController(
            UserManager<User> userManager,
            IComicsService comicsService,
            IHtmlService htmlService)
        {
            this.userManager = userManager;
            this.comicsService = comicsService;
            this.htmlService = htmlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new ComicCreateViewModel()
            {
                ReleaseDate = DateTime.UtcNow,
                Price = 3.99m
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComicCreateViewModel comicModel, IFormFile poster)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            if (poster != null)
            {
                if (!poster.FileName.EndsWith(WebConstants.JpgExtension)
                    || poster.Length > DataConstants.ReviewPosterFileLength)
                {
                    TempData.AddErrorMessage(WebTextConstants.ReviewComicPosterErrorMessage);
                    return RedirectToAction(nameof(Create));
                }
            }

            var fileContents = await poster.ToByteArrayAsync();
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
    }
}