namespace ReviewYourFavourites.Data.Models
{
    using System.Collections.Generic;

    public class Movie : Review
    {
        public string Director { get; set; }

        public int ReleaseYear { get; set; }

        //TODO: Genres Google-EnumFlags

        public string AuthorId { get; set; }

        public User Author { get; set; }

        //public List<UserMovieLikes> UserMovieLikes = new List<UserMovieLikes>();
    }
}
