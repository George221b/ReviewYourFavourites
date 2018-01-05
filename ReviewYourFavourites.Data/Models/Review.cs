namespace ReviewYourFavourites.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Review
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ReviewTitleMinLength)]
        [MaxLength(DataConstants.ReviewTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.ReviewContentMinLength)]
        [MaxLength(DataConstants.ReviewContentMaxLength)]
        public string Content { get; set; }

        [Range(DataConstants.ReviewRatingMinRange,
            DataConstants.ReviewRatingMaxRange)]
        public int Rating { get; set; }

        [Range(DataConstants.ReviewViewsMinRange,
            DataConstants.ReviewViewsMaxRange)]
        public int Views { get; set; }

        [MaxLength(DataConstants.ReviewPosterFileLength)]
        public byte[] Poster { get; set; }
    }
}
