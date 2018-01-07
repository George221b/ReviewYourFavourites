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
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            builder
                .Entity<User>()
                .HasMany(u => u.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
