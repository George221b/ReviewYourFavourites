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

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comic> Comics { get; set; }
        //public DbSet<UserComicLikes> UserComicLikes { get; set; }
        //public DbSet<UserMovieLikes> UserMovieLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<UserComicLikes>()
            //    .HasKey(ucl => new { ucl.UserId, ucl.ComicId });

            //builder.Entity<UserMovieLikes>()
            //    .HasKey(uml => new { uml.UserId, uml.MovieId });

            builder
                .Entity<User>()
                .HasMany(u => u.Comics)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);

            builder
                .Entity<User>()
                .HasMany(u => u.Movies)
                .WithOne(m => m.Author)
                .HasForeignKey(m => m.AuthorId);

            //builder
            //    .Entity<UserComicLikes>()
            //    .HasOne(ucl => ucl.User)
            //    .WithMany(u => u.ComicLiked)
            //    .HasForeignKey(ucl => ucl.UserId);

            //builder
            //    .Entity<UserComicLikes>()
            //    .HasOne(ucl => ucl.Comic)
            //    .WithMany(c => c.UserComicLikes)
            //    .HasForeignKey(ucl => ucl.ComicId);

            //builder
            //    .Entity<UserMovieLikes>()
            //    .HasOne(uml => uml.User)
            //    .WithMany(u => u.MovieLiked)
            //    .HasForeignKey(uml => uml.UserId);

            //builder
            //    .Entity<UserMovieLikes>()
            //    .HasOne(uml => uml.Movie)
            //    .WithMany(m => m.UserMovieLikes)
            //    .HasForeignKey(uml => uml.MovieId);

            base.OnModelCreating(builder);
        }
    }
}
