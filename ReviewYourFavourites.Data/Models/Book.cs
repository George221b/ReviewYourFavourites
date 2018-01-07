namespace ReviewYourFavourites.Data.Models
{
    using ReviewYourFavourites.Data.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class Book : Review
    {
        [Required]
        [Name]
        public string BookAuthor { get; set; }

        [Range(DataConstants.BookPagesMinRange,
            DataConstants.BookPagesMaxRange)]
        public int Pages { get; set; }

        [Range(DataConstants.BookPublishedYearMinRange,
            DataConstants.BookPublishedYearMaxRange)]
        public int PublishedYear { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
