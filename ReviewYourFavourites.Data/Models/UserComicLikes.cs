namespace ReviewYourFavourites.Data.Models
{
    public class UserComicLikes
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int ComicId { get; set; }

        public Comic Comic { get; set; }
    }
}
