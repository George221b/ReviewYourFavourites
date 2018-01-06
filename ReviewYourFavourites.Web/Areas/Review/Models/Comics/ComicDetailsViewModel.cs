using ReviewYourFavourites.Services.Review.Models;

namespace ReviewYourFavourites.Web.Areas.Review.Models.Comics
{
    public class ComicDetailsViewModel
    {
        public DetailsComicServiceModel Comic { get; set; }

        public bool IsAuthorOfReview { get; set; }
    }
}
