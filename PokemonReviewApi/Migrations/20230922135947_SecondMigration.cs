using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Pokemons_PokemonId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Reviewers_ReviewerId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_PokemonId",
                table: "Reviews",
                newName: "IX_Reviews_PokemonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Pokemons_PokemonId",
                table: "Reviews",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Pokemons_PokemonId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Review",
                newName: "IX_Review_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PokemonId",
                table: "Review",
                newName: "IX_Review_PokemonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Pokemons_PokemonId",
                table: "Review",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Reviewers_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
