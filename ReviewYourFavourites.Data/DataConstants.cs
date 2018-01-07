namespace ReviewYourFavourites.Data
{
    public class DataConstants
    {
        public const int ImageUrlMinLength = 10;
        public const int ImageUrlMaxLength = 2000;

        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 30;

        public const int ReviewTitleMinLength = 2;
        public const int ReviewTitleMaxLength = 70;

        public const int ReviewContentMinLength = 10;
        public const int ReviewContentMaxLength = 10000;

        public const int ReviewRatingMinRange = 1;
        public const int ReviewRatingMaxRange = 10;

        public const int ComicWriterMinLength = 2;
        public const int ComicWriterMaxLength = 100;

        public const double ComicPriceMinRange = 0.0;
        public const double ComicPriceMaxRange = 10000000.00;

        public const int ReviewViewsMinRange = 0;
        public const int ReviewViewsMaxRange = int.MaxValue;

        public const int BookPagesMinRange = 0;
        public const int BookPagesMaxRange = 100000;

        public const int BookPublishedYearMinRange = 0;
        public const int BookPublishedYearMaxRange = 2100;

        public const int MovieReleasedYearMinRange = 1800;
        public const int MovieReleasedYearMaxRange = 2100;

        public const int ReviewPosterFileLength = 2 * 1024 * 1024;
    }
}
