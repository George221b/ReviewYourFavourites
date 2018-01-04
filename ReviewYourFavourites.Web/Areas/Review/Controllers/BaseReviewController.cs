namespace ReviewYourFavourites.Web.Areas.Review.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.ReviewArea)]
    [Authorize]
    public abstract class BaseReviewController : Controller
    {
    }
}