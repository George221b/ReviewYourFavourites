namespace ReviewYourFavourites.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using ReviewYourFavourites.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        // TODO
        //[Required]
        //public byte[] ProfilePhoto { get; set; }

        public Gender Gender { get; set; }
    }
}
