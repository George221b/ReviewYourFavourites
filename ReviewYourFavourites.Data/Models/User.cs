namespace ReviewYourFavourites.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using ReviewYourFavourites.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {        
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        //// TODO
        ////[Required]
        ////public byte[] ProfilePhoto { get; set; }

        public Gender Gender { get; set; }

        public List<Comic> Comics { get; set; } = new List<Comic>();

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<UserComicLikes> ComicLiked = new List<UserComicLikes>();

        public List<UserMovieLikes> MovieLiked = new List<UserMovieLikes>();
    }
}
