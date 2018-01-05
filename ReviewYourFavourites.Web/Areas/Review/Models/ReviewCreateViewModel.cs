using Microsoft.AspNetCore.Http;
using ReviewYourFavourites.Data;
using System.ComponentModel.DataAnnotations;

namespace ReviewYourFavourites.Web.Areas.Review.Models
{
    public class ReviewCreateViewModel
    {
        [Required]
        [MinLength(DataConstants.ReviewTitleMinLength)]
        [MaxLength(DataConstants.ReviewTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.ReviewContentMinLength)]
        [MaxLength(DataConstants.ReviewTitleMaxLength)]
        public string Content { get; set; }

        [Range(DataConstants.ReviewRatingMinRange,
            DataConstants.ReviewRatingMaxRange)]
        public int Rating { get; set; }
    }
}
