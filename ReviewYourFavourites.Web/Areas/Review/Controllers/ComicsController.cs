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

    public class ComicsController : BaseReviewController
    {
        private readonly UserManager<User> userManager;

        public ComicsController(
            UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
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
                if (!poster.FileName.EndsWith(".jpg")
                    || poster.Length > DataConstants.ReviewPosterFileLength)
                {
                    TempData.AddErrorMessage("The poster must be with .jpg extension and be less that 2 MBs.");
                    return RedirectToAction(nameof(Create));
                }
            }

            var fileContents = await poster.ToByteArrayAsync();
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SaveExamSubmission(id, userId, fileContents);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Your comic review was created successfully!");

            return RedirectToAction(nameof(Index));
        }
    }
}