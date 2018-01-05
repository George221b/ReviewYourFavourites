namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReviewYourFavourites.Web.Areas.Review.Models.Comics;
    using System.Threading.Tasks;
    using Models;
    using System;

    public class ComicsController : BaseReviewController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = new ComicCreateViewModel()
            {
                BaseModel = new ReviewCreateViewModel(),
                ReleaseDate = DateTime.UtcNow,
                Price = 3.99m
            };

            return View(model);
        }
    }
}