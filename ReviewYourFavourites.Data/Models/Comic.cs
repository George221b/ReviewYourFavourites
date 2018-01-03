namespace ReviewYourFavourites.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comic : Review
    {
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(DataConstants.ComicWriterMinLength)]
        [MaxLength(DataConstants.ComicWriterMaxLength)]
        public string Writer { get; set; }

        [Range(DataConstants.ComicPriceMinRange,
            DataConstants.ComicPriceMaxRange)]
        public decimal Price { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public List<UserComicLikes> UserComicLikes = new List<UserComicLikes>();
    }
}
