namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ComicsController : BaseReviewController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}