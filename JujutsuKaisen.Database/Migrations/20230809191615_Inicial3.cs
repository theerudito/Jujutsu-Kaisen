using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JujutsuKaisen.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "IdClan",
                table: "Characters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IdClan",
                table: "Characters",
                column: "IdClan");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Clan_IdClan",
                table: "Characters",
                column: "IdClan",
                principalTable: "Clan",
                principalColumn: "IdClan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Clan_IdClan",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_IdClan",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "IdClan",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClanIdClan",
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
    }
}
