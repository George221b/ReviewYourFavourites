namespace ReviewYourFavourites.Data.Models
{
    using ReviewYourFavourites.Data.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class Movie : Review
    {
        [Name]
        public string Director { get; set; }

        [Range(DataConstants.MovieReleasedYearMinRange,
            DataConstants.MovieReleasedYearMaxRange)]
        public int ReleaseYear { get; set; }

        //TODO: Genres Google-EnumFlags

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
