namespace ReviewYourFavourites.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string SubstringWithThreeDots(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length) + "...";
            }
            else
            {
                return text;
            }
        }
    }
}
