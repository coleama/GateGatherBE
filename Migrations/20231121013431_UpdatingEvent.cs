using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BECapstone.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_EndTimeId",
                table: "Events",
                column: "EndTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_StartTimeId",
                table: "Events",
                column: "StartTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TimeSlots_EndTimeId",
                table: "Events",
                column: "EndTimeId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TimeSlots_StartTimeId",
                table: "Events",
                column: "StartTimeId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_TimeSlots_EndTimeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_TimeSlots_StartTimeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EndTimeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_StartTimeId",
                table: "Events");
        }
    }
}
