﻿namespace ReviewYourFavourites.Web.Areas.Review.Models.Comics
{
    using ReviewYourFavourites.Data;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ComicCreateEditDeleteViewModel : ReviewCreateViewModel
    {
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(DataConstants.ComicWriterMinLength)]
        [MaxLength(DataConstants.ComicWriterMaxLength)]
        public string Writer { get; set; }

        [Range(DataConstants.ComicPriceMinRange,
            DataConstants.ComicPriceMaxRange)]
        public decimal Price { get; set; }
    }
}