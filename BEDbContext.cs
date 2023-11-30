using Microsoft.EntityFrameworkCore;
using BECapstone.Models;
using Microsoft.Extensions.Logging;

namespace BECapstone
{
    public class BEDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<PlayType> PlayTypes { get; set; }
        public DbSet<TimeSlots> TimeSlots { get; set; }
        public DbSet<Class> Class { get; set; }

        public BEDbContext(DbContextOptions<BEDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Email = "cole.ama@gmail.com", Name = "Cole", uid = ""}

            });
            modelBuilder.Entity<PlayType>().HasData(new PlayType[]
            {
                new PlayType { Id = 1, Name = "Good"},
                new PlayType { Id = 2, Name = "Evil"}
            });
            for (int i = 1; i <= 12; i++)
            {
                modelBuilder.Entity<TimeSlots>().HasData(new TimeSlots { Id = i, Value = $"{i}:00 AM" });
                modelBuilder.Entity<TimeSlots>().HasData(new TimeSlots { Id = i + 12, Value = $"{i}:00 PM" });
            }
            modelBuilder.Entity<Events>().HasData(new Events { Id = 1, Name = "Cole's Event", EndTimeId = 13, StartTimeId = 2, PlayTypeId = 1, uid = "", Date = "10/23/2023"});
            modelBuilder.Entity<Class>().HasData(new Class[]
            {
                new Class { Id = 1, Name = "Fighter", Description = "A master of martial combat, skilled with a variety of weapons and armor", image = "https://i.pinimg.com/originals/2c/8a/39/2c8a3940f4d506f7a7198a8035ae84c5.png"},
                new Class { Id = 2, Name = "Barbarian", Description = "A fierce warrior who can enter a battle rage", image = "https://i.pinimg.com/originals/c7/fe/25/c7fe251cd11a2ecb590d7d9efa596a49.png"},
                new Class { Id = 3, Name = "Bard", Description = "An inspiring magician whose power echoes the music of creation", image = "https://i.pinimg.com/originals/28/c7/95/28c795e4db4c71da104642b271964c3a.png"},
                new Class { Id = 4, Name = "Cleric", Description = "A priestly champion who wields divine magic in service of a higher power", image = "https://www.kindpng.com/picc/m/627-6275446_static-media-cleric-logo-536f9581-dnd-5e-cleric.png"},
                new Class { Id = 5, Name = "Druid", Description = "A priest of the Old Faith, wielding the powers of nature and adopting animal forms", image = "https://i.pinimg.com/736x/97/96/46/979646f11eddd53c027dba86dfc428df--players-handbook-nerd-art.jpg" },
                new Class { Id = 6, Name = "Wizard", Description = "A scholarly magic-user capable of manipulating the structures of reality", image = "https://dreionsden.files.wordpress.com/2019/08/dnd5e_classsymb_wizard.png?w=1200"},
                new Class { Id = 7, Name = "Paladin", Description = "A holy warrior bound to a sacred oath", image = "https://i.pinimg.com/originals/ed/6a/cb/ed6acb4c1a9381e1efb232d4ea0916ea.jpg"},
                new Class { Id = 8, Name = "Rogue", Description = "A scoundrel who uses stealth and trickery to overcome obstacles and enemies", image = "https://i.pinimg.com/originals/bb/70/66/bb70661930e5533fcf2fb396855b0aa5.png" },
                new Class { Id = 9, Name = "Warlock", Description = "A wielder of magic that is derived from a bargain with an extraplanar entity", image = "https://i.pinimg.com/564x/9e/18/b2/9e18b24ae454cfec5a88bb15da8bee54.jpg"},
                new Class { Id = 10, Name = "Sorcerer", Description = "A spellcaster who draws on inherent magic from a gift or bloodline", image = "https://i.pinimg.com/564x/ca/15/24/ca15241cb07dd87c2d09287ee597f6ef.jpg"},
                new Class { Id = 11, Name = "Ranger", Description = "A warrior who combats threats on the edges of civilization", image = "https://i.pinimg.com/564x/1c/af/b8/1cafb836d4bf83e941c6b6870ff03ac8.jpg"},
                new Class { Id = 12, Name = "Monk", Description = "A master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection", image = "https://i.pinimg.com/564x/f5/9a/ee/f59aee806df75cdce2fd591d96423270.jpg"}
             });
        }
    }
}
