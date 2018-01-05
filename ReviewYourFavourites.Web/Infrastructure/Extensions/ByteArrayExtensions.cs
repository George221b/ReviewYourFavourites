namespace ReviewYourFavourites.Web.Infrastructure.Extensions
{
    using System;

    public static class ByteArrayExtensions
    {
        public static string ToImgSrc(this byte[] byteArray)
        {
            var base64 = Convert.ToBase64String(byteArray);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);

            return imgSrc;
        }
    }
}
