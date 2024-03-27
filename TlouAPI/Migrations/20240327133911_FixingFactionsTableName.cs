using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TlouAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixingFactionsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faction",
                table: "Faction");

            migrationBuilder.RenameTable(
                name: "Faction",
                newName: "Factions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions",
                table: "Factions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.RenameTable(
                name: "Factions",
                newName: "Faction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faction",
                table: "Faction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
