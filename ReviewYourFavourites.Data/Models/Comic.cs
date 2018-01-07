namespace ReviewYourFavourites.Data.Models
{
    using ReviewYourFavourites.Data.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comic : Review
    {
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(DataConstants.ComicWriterMinLength)]
        [MaxLength(DataConstants.ComicWriterMaxLength)]
        [Name]
        public string Writer { get; set; }

        [Range(DataConstants.ComicPriceMinRange,
            DataConstants.ComicPriceMaxRange)]
        public decimal Price { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
