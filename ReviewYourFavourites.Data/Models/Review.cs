namespace ReviewYourFavourites.Data.Models
{
    using System;
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
        [MaxLength(DataConstants.ReviewTitleMaxLength)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        [Range(DataConstants.ReviewRatingMinRange,
            DataConstants.ReviewRatingMaxRange)]
        public int Rating { get; set; }
    }
}
