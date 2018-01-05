namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Data;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Services.Html;
    using ReviewYourFavourites.Services.Review;
    using ReviewYourFavourites.Web.Areas.Review.Models.Comics;
    using ReviewYourFavourites.Web.Infrastructure.Extensions;
    using System;
    using System.Threading.Tasks;

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

        public async Task<IActionResult> Index() //TODO: pagination
        {
            var comics = await this.comicsService.All();

            return View(comics);
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

        public async Task<IActionResult> Details(int id)
        {
            var comic = await this.comicsService.GetById(id);

            if (comic == null)
            {
                return NotFound();
            }

            await this.comicsService.GiveView(id);

            return View(comic);
        }
    }
}