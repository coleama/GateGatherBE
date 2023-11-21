using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BECapstone.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    uid = table.Column<string>(type: "text", nullable: false),
                    StartTimeId = table.Column<int>(type: "integer", nullable: false),
                    EndTimeId = table.Column<int>(type: "integer", nullable: false),
                    PlayTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EventsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventsUser",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUser", x => new { x.EventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_EventsUser_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassUser",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUser", x => new { x.ClassId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ClassUser_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "EventsId", "Name" },
                values: new object[] { 1, null, "Fighter" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EndTimeId", "Name", "PlayTypeId", "StartTimeId", "uid" },
                values: new object[] { 1, 13, "Cole's Event", 1, 2, "" });

            migrationBuilder.InsertData(
                table: "PlayTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Good" },
                    { 2, "Evil" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "1:00 AM" },
                    { 2, "2:00 AM" },
                    { 3, "3:00 AM" },
                    { 4, "4:00 AM" },
                    { 5, "5:00 AM" },
                    { 6, "6:00 AM" },
                    { 7, "7:00 AM" },
                    { 8, "8:00 AM" },
                    { 9, "9:00 AM" },
                    { 10, "10:00 AM" },
                    { 11, "11:00 AM" },
                    { 12, "12:00 AM" },
                    { 13, "1:00 PM" },
                    { 14, "2:00 PM" },
                    { 15, "3:00 PM" },
                    { 16, "4:00 PM" },
                    { 17, "5:00 PM" },
                    { 18, "6:00 PM" },
                    { 19, "7:00 PM" },
                    { 20, "8:00 PM" },
                    { 21, "9:00 PM" },
                    { 22, "10:00 PM" },
                    { 23, "11:00 PM" },
                    { 24, "12:00 PM" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "uid" },
                values: new object[] { 1, "cole.ama@gmail.com", "Cole", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Class_EventsId",
                table: "Class",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUser_UsersId",
                table: "ClassUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUser_UsersId",
                table: "EventsUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassUser");

            migrationBuilder.DropTable(
                name: "EventsUser");

            migrationBuilder.DropTable(
                name: "PlayTypes");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
