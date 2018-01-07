namespace ReviewYourFavourites.Web.Models.Users
{
    using ReviewYourFavourites.Services.Models;

    public class UserProfileViewModel
    {
        public UserProfileServiceModel UserInfo { get; set; }

        public int ComicViewsTotal { get; set; }

        public int MovieViewsTotal { get; set; }

        public int BookViewsTotal { get; set; }
    }
}
