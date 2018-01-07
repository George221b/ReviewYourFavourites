namespace ReviewYourFavourites.Services.Models
{
    using ReviewYourFavourites.Common.Mapping;
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Data.Models.Enums;
    using System;

    public class UserProfileServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public DateTime Birthday { get; set; }

        public byte[] Avatar { get; set; }

        public Gender Gender { get; set; }
    }
}
