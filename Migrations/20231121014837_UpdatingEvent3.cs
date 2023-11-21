using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BECapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEvent3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Events_EventsId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_EventsId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "Class");

            migrationBuilder.CreateTable(
                name: "ClassEvents",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    EventsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassEvents", x => new { x.ClassId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_ClassEvents_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassEvents_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlayTypeId",
                table: "Events",
                column: "PlayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassEvents_EventsId",
                table: "ClassEvents",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PlayTypes_PlayTypeId",
                table: "Events",
                column: "PlayTypeId",
                principalTable: "PlayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PlayTypes_PlayTypeId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "ClassEvents");

            migrationBuilder.DropIndex(
                name: "IX_Events_PlayTypeId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "Class",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Class_EventsId",
                table: "Class",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Events_EventsId",
                table: "Class",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
