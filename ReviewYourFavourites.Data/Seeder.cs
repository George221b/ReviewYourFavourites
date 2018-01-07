namespace ReviewYourFavourites.Data
{
    using ReviewYourFavourites.Data.Models;
    using ReviewYourFavourites.Data.Models.Enums;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        public const string AdministratorUsername = "Administrator";
        public const string ProUserUsername = "ProUser";

        private readonly ReviewYourFavouritesDbContext db;

        public Seeder(ReviewYourFavouritesDbContext db)
        {
            this.db = db;
        }
        // SEEDING TEST DATA
        public async Task Seed()
        {
            var admin = this.db.Users.FirstOrDefault(u => u.UserName == AdministratorUsername);
            var pro = this.db.Users.FirstOrDefault(u => u.UserName == ProUserUsername);

            var defaultImage = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/default.jpg");

            if (this.db.Users.Count() <= 3)
            {
                var normal = this.db.Users.FirstOrDefault(u => u.UserName == "Normal");

                if (normal == null)
                {
                    normal = new User()
                    {
                        Email = "normal@normal.com",
                        UserName = "Normal",
                        Name = "Normal Name",
                        Birthday = DateTime.UtcNow,
                        Gender = Gender.Female
                    };

                    await this.db.Users.AddAsync(normal);
                    await this.db.SaveChangesAsync();
                }
            }
            var normalId = this.db.Users.First(u => u.UserName == "Normal").Id;

            if (!this.db.Comics.Any())
            {
                var image1 = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/1.jpg");
                var image2 = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/1.jpg");
                var image3 = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/1.jpg");
                var image4 = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/1.jpg");
                var image5 = File.ReadAllBytes("../ReviewYourFavourites.Web/wwwroot/images/1.jpg");

                var comic1 = new Comic()
                {
                    AuthorId = admin.Id,
                    Title = "BATMAN #38",
                    Content = @"Tom King tends to write longer Batman arcs that manage to avoid feeling like they’re being written for a trade. With Batman #38, King shows he’s just as skilled in writing an amazing standalone story.  Batman encounters a familiar scenario as a young body returns home and finds his parents dead. Shattered and broken, the boy goes to the one person who can most easily relate in Gotham — Bruce Wayne.  For fans of all the various aspects of Batman, King hasn’t touched on his detective skills that much so this made for a great showcase of his investigative prowess. I really enjoyed how King showed Batman’s obsessive nature in trying to crack the case whether in bed with Selina or chatting over dinner with Alfred. That’s a personality trait King hasn’t focused on a lot and I hope King incorporates more detective/investigative angles to future Batman stories.  Artist Travis Moore has a style reminiscent of Kurt Busiek’s Astro City artist partner Brent Anderson. Moore’s panel work is clean and he sets the story up so smoothly the payoff pages have more impact. With this kind of story, it’s better to have an artist who understands the need to slowly lead the reader along and shock them when necessary and Moore does a tremendous job here. Giulia Brusco colorist complements the simple style nicely. Big, splashy colors wouldn’t work here and this was a nice fit.  By the end of this issue, King offers yet another layer to his already impressive Batman resume and introduces a potentially dangerous new Rogue.  It’s crazy to say this considering the consistent quality of the title, but Batman is on an absolutely can’t miss roll. King is delivering some of the best work in comics right now by devoting just as much time to the man behind the cowl as the crime fighting vigilante protecting Gotham. –Jeffrey Lyles",
                    Price = 3.99m,
                    PublishedOn = DateTime.UtcNow,
                    ReleaseDate = DateTime.UtcNow.AddDays(-15).AddMonths(-10),
                    Writer = "Tom King",
                    Rating = 7,
                    Poster = image1
                };

                var comic2 = new Comic()
                {
                    AuthorId = admin.Id,
                    Title = "BATMAN: WHITE KNIGHT #4",
                    Content = @"Analysis: Wow, that was such an amazing issue that I hardly know where to begin. While the mystery and sincerity of Jack’s transformation has been an underlying theme of the whole series thus far, it’s in this issue where I’ve really started to fully believe that his transformation is genuine. He’s not perfect by any stretch, he’s always trying to find ways to score political points, but he also seems to want to make Gotham a better place. His partnership with Duke Thomas seems unlikely at first, but their association is mutually beneficial to their goals. Napier is continuing who use anti-establishment rhetoric to galvanize support in less fortunate socio-economic communities. I think part of the reason the character’s words resonate with the reader is because it’s so topical to what’s going on in the world today. The protest march that Napier orchestrates and the resulting confrontation with the police is a snapshot of how many of these events play out in our world. Gordon and Montoya seem ready to conduct themselves as professionals, but Bullock lets personal feelings cloud his judgement and he becomes hostile to Duke. Duke also aggravates the situation by using incendiary language towards Montoya who is just trying to help. Batman’s aggressive approach is the spark that sets off more direct hostilities between the two sides. Napier’s ability to calm the crowd and avert any causalities is a political win for him over Batman and also sends the message that violence is not the answer.     Batman’s relationship with Gordon also suffers some blows in this issue. This relationship has typically been a foundation of all Batman stories, but it really starts to come apart here. The impression I got of Gordon’s character in this issue is that he is like a man who was been asleep for a long time and is only waking up very slowly. Napier is offering him a better solution and Gordon is slowly starting to realize that Batman might be causing more problems than he is solving. He is understandably mad that Batman never shared any of his tech with his officers because it might have saved some lives. Keep in mind that earlier in the story Gordon was the most staunch, pro-Batman supporter on the police force. He seems to be gradually remembering what it means to be a good cop and prioritize the rights of citizens and the lives of his officers over his relationship with Batman. However, he still has a ways to go as he is still remarkably silent when all hell breaks loose under his nose as it did during the protest. The panel with the broken Bat-Signal on the ground between Gordon and Batman is an apt metaphor for where their relationship is heading in this issue.     Murphy continues to use the Gotham news show to showcase how events like the protest are endlessly dissected by pundits as well as how that shapes public opinion. Both the anchors offer differing opinions on Napier’s growing popularity, and their opinions are largely shaped by their own background and perspective of the world. It also illustrates how a vigilante like Batman ducks accountability for his actions because he never makes statements to the public. Napier’s idea to redistribute the Batman Devastation Fund is a win-win situation for everyone except Batman. Napier is able to earn goodwill from the police department, spin public perception in his favor and further demonize Batman as the true enemy of Gotham. Napier’s request that the vigilantes wear body cameras and use a GPS is all about holding them accountable. The fact that they can keep their identities means who they are is not as relevant as what they do. That being said, Napier’s suggestion that Batgirl would listen to Gordon hints at the fact that he might know more about the Bat-Family’s identities that he is letting on. Everyone seems to be starting to come around to Napier’s way of doing things. Even Batgirl and Nightwing are clearly tempted when they actually see the results of his plan at work. We’ve seen in the past issues that they’ve become increasingly disenchanted with Batman’s methods, and perhaps Napier’s way is offering them a more appealing alternative.",
                    Price = 3.99m,
                    PublishedOn = DateTime.UtcNow,
                    ReleaseDate = DateTime.UtcNow.AddDays(-15).AddMonths(-10),
                    Writer = "Sean Murphy",
                    Rating = 10,
                    Poster = image2
                };

                var comic3 = new Comic()
                {
                    AuthorId = pro.Id,
                    Title = "DOOMSDAY CLOCK #2",
                    Content = @"STORY: We follow the group of Ozymandias, Rorschach, and the villainous couple Mime and Marionette as they escape their world to the DC Universe. The group needs to find Dr. Manhattan, but first, have to locate some allies on this world. This leads to the two heroes looking up and searching for the two smartest men in the world: Bruce Wayne and Lex Luthor. The heroes agree to split up, which leads to the first encounters between these two legendary universes.  If you didn’t like the lack of the DC Universe in the first issue, this second one makes up for that many times over. We get a look into this universe through the eyes of the visitors from the Watchmen world and it gives off the sense we’re learning alongside them. Their first encounters with members of the DC Universe are exactly how I’d imagine it, especially the verbal sparring between Ozymandias and Lex Luthor. The back and forth between the two smartest men from both Earths is actually quite interesting to see.  I think the real fault I have with the story is the political climate of the DC Universe. Not that it isn’t interesting, far from it, but it comes off as confusing. The DC Universe is in the midst of unrest due to The Supermen Theory. The theory states that the U.S. Government is creating the superheroes and villains in America as weapons of mass destruction. This leads to the public denouncing heroes, such as Batman. The problem with this theory is the fact that these living WMDs in question help the entire world almost daily. Most of them work outside the government, including the all-powerful Man of Steel. I understand it’s trying to be parallel to the Watchmen Earth, but unless this is an alternate DCU, one would think that the League has enough presence to dissuade that.  ART: What can be said about Gary Frank’s art that hasn’t been said before? It’s dark, realistic, and fits the tone of the story. Brad Anderson’s colors compliment the pencil work, allowing the characters to pop off the page and make the world feel more alive. With these two working together, this series will be one of the most beautiful years to come.  CONCLUSION: This is a fantastic second issue. The plot progresses as the two universes finally meet, the art is fantastic, and has an ending that will leave you longing for the next issue. All we have now is to countdown the days till the next installment.",
                    Price = 3.99m,
                    PublishedOn = DateTime.UtcNow,
                    ReleaseDate = DateTime.UtcNow.AddDays(-15).AddMonths(-10),
                    Writer = "Geoff Johns",
                    Rating = 9,
                    Poster = image3
                };

                var comic4 = new Comic()
                {
                    AuthorId = pro.Id,
                    Title = "DETECTIVE COMICS #971",
                    Content = @"Things are looking bleak for Batman and the Gotham Knights. Mayor Akins has withdrawn support for our heroes, and imposed sanctions on Jim Gordon helping them. Killer Moth is gathering an army of villains to fight them, and the Victim Syndicate have Clayface under lockdown. By the end of this issue we see dissent within Batman’s own ranks, and one of the team finally turning on their own. The Fall Of The Batmen has well and truly begun!  This issue is top notch from cover to cover. We get to see the Dark Knight at his awesome fighting best, and both dialogue and action are consistently excellent. James Tynion IV weaves a hell of a tale, and keeps the tension levels high. Every nerve is on edge, and by the final shocking page we know that the Knights are in real trouble.  A particular bone of contention is the now strained relationship between Red Robin and Batwoman, after the events of the incredible “A Lonely Place Of Living”. Could Tim Drake actually be aligning himself with The Colony? This group of mercenaries, led by Kate’s own father, have been a thorn in Batman’s side since the dawn of the DC Rebirth.  This issue delivers, not only with great writing (no surprise), but the art is phenomenal too. The team of Miguel Mendonca and Diana Egea continue to provide the level of excellence that makes this series stand up against anything else on the shelves. Their storytelling is crisp, fluid, and fits in perfectly with that of all the excellent art teams that have preceded them. Their version of Batman, especially in the terrific fight scenes against the Syndicate, are absolutely first rate.",
                    Price = 3.99m,
                    PublishedOn = DateTime.UtcNow,
                    ReleaseDate = DateTime.UtcNow.AddDays(-15).AddMonths(-10),
                    Writer = "James Tynion IV",
                    Rating = 9,
                    Poster = image4
                };

                var comic5 = new Comic()
                {
                    AuthorId = normalId,
                    Title = "AQUAMAN #31",
                    Content = @"The revolution is on. Aquaman has taken lead of the Undercurrent with the help of Dolphin and Jurok Byss. Vulko wants Aquaman to take it to the next level, strike a symbolic blow, and bring down the Crown of Thorns. Arthur is reluctant, as he doesn’t want to put the Undercurrent at such a great risk when there are still so few. The Widowhood’s agent, Ondine, has a potential solution to that as well. The gangs of the Ninth Tride are at war, and their kind is being hunted by Corum Rath’s regime. If Aquaman can unite them, the Undercurrent would have more muscle to throw against the tyrannical king.",
                    Price = 3.99m,
                    PublishedOn = DateTime.UtcNow,
                    ReleaseDate = DateTime.UtcNow.AddDays(-15).AddMonths(-10),
                    Writer = "Dan Abnett",
                    Rating = 9,
                    Poster = image5
                };
            }

            if (!this.db.Movies.Any())
            {
                // SEED
            }

            if (!this.db.Books.Any())
            {
                // SEED
            }
        }
    }
}
