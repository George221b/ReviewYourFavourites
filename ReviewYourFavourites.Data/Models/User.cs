namespace ReviewYourFavourites.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using ReviewYourFavourites.Data.Attributes;
    using ReviewYourFavourites.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {        
        [Required]
        [Name]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        //// TODO
        ////public byte[] ProfilePhoto { get; set; }

        public Gender Gender { get; set; }

        public List<Comic> Comics { get; set; } = new List<Comic>();

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
