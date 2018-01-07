namespace ReviewYourFavourites.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;

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

        public static string FormatName(this string name)
        {
            var nameParts = name.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return string.Join(' ', nameParts);

        }
    }
}
