namespace ReviewYourFavourites.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ReviewYourFavourites.Data.Models;

    public class ReviewYourFavouritesDbContext : IdentityDbContext<User>
    {
        public ReviewYourFavouritesDbContext(DbContextOptions<ReviewYourFavouritesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
