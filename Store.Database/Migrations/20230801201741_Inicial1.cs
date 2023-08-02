using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClanIdClan",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdClan",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClanIdClan",
                table: "Characters",
                column: "ClanIdClan");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Clan_ClanIdClan",
                table: "Characters",
                column: "ClanIdClan",
                principalTable: "Clan",
                principalColumn: "IdClan",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Clan_ClanIdClan",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClanIdClan",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ClanIdClan",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IdClan",
                table: "Characters");
        }
    }
}
