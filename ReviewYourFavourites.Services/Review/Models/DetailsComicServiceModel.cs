using AutoMapper;
using ReviewYourFavourites.Common.Mapping;
using ReviewYourFavourites.Data.Models;
using System;

namespace ReviewYourFavourites.Services.Review.Models
{
    public class DetailsComicServiceModel : IMapFrom<Comic>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public int Views { get; set; }

        public byte[] Poster { get; set; }

        public DateTime PublishedOn { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Writer { get; set; }

        public decimal Price { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Comic, DetailsComicServiceModel>()
                .ForMember(dc => dc.AuthorUsername, cfg => cfg.MapFrom(c => c.Author.UserName));
    }
}
