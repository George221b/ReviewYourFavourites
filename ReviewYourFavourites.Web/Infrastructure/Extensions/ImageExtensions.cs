namespace ReviewYourFavourites.Web.Infrastructure.Extensions
{
    using System.Drawing;
    using System.IO;

    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image img)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}
