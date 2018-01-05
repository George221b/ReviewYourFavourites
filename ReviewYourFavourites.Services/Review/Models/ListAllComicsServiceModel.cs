namespace ReviewYourFavourites.Services.Review.Models
{
    using ReviewYourFavourites.Common.Mapping;
    using ReviewYourFavourites.Data.Models;

    public class ListAllComicsServiceModel : IMapFrom<Comic>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public byte[] Poster { get; set; }

        public int Rating { get; set; }

        public decimal Price { get; set; }
    }
}
