using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BECapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEvent5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Class",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Class",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "image" },
                values: new object[] { "A master of martial combat, skilled with a variety of weapons and armor", "https://i.pinimg.com/originals/2c/8a/39/2c8a3940f4d506f7a7198a8035ae84c5.png" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "Description", "Name", "image" },
                values: new object[,]
                {
                    { 2, "A fierce warrior who can enter a battle rage", "Barbarian", "https://i.pinimg.com/originals/c7/fe/25/c7fe251cd11a2ecb590d7d9efa596a49.png" },
                    { 3, "An inspiring magician whose power echoes the music of creation", "Bard", "https://i.pinimg.com/originals/28/c7/95/28c795e4db4c71da104642b271964c3a.png" },
                    { 4, "A priestly champion who wields divine magic in service of a higher power", "Cleric", "https://www.kindpng.com/picc/m/627-6275446_static-media-cleric-logo-536f9581-dnd-5e-cleric.png" },
                    { 5, "A priest of the Old Faith, wielding the powers of nature and adopting animal forms", "Druid", "https://i.pinimg.com/736x/97/96/46/979646f11eddd53c027dba86dfc428df--players-handbook-nerd-art.jpg" },
                    { 6, "A scholarly magic-user capable of manipulating the structures of reality", "Wizard", "https://dreionsden.files.wordpress.com/2019/08/dnd5e_classsymb_wizard.png?w=1200" },
                    { 7, "A holy warrior bound to a sacred oath", "Paladin", "https://i.pinimg.com/originals/ed/6a/cb/ed6acb4c1a9381e1efb232d4ea0916ea.jpg" },
                    { 8, "A scoundrel who uses stealth and trickery to overcome obstacles and enemies", "Rogue", "https://i.pinimg.com/originals/bb/70/66/bb70661930e5533fcf2fb396855b0aa5.png" },
                    { 9, "A wielder of magic that is derived from a bargain with an extraplanar entity", "Warlock", "https://i.pinimg.com/564x/9e/18/b2/9e18b24ae454cfec5a88bb15da8bee54.jpg" },
                    { 10, "A spellcaster who draws on inherent magic from a gift or bloodline", "Sorcerer", "https://i.pinimg.com/564x/ca/15/24/ca15241cb07dd87c2d09287ee597f6ef.jpg" },
                    { 11, "A warrior who combats threats on the edges of civilization", "Ranger", "https://i.pinimg.com/564x/1c/af/b8/1cafb836d4bf83e941c6b6870ff03ac8.jpg" },
                    { 12, "A master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection", "Monk", "https://i.pinimg.com/564x/f5/9a/ee/f59aee806df75cdce2fd591d96423270.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Class");
        }
    }
}
