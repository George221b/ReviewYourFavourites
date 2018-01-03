namespace ReviewYourFavourites.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        private readonly ReviewYourFavouritesDbContext db;

        public Seeder(ReviewYourFavouritesDbContext db)
        {
            this.db = db;
        }

        public async Task Seed()
        {
            var admin = this.db.Users.FirstOrDefault(u => u.UserName == "Adminsitrator");

            var defaultImage = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/default.jpg");

            //TODO: SEEd
        }
    }
}
