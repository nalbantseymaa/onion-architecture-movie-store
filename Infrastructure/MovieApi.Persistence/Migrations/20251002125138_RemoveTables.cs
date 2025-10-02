using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovies_Customers_CustomerId",
                table: "PurchasedMovies");

            migrationBuilder.DropTable(
                name: "CustomerGenres");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "PurchasedMovies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovies_CustomerId",
                table: "PurchasedMovies",
                newName: "IX_PurchasedMovies_UserId");

            migrationBuilder.CreateTable(
                name: "UserGenres",
                columns: table => new
                {
                    FavoriteGenresId = table.Column<long>(type: "bigint", nullable: false),
                    UsersByGenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenres", x => new { x.FavoriteGenresId, x.UsersByGenreId });
                    table.ForeignKey(
                        name: "FK_UserGenres_Genres_FavoriteGenresId",
                        column: x => x.FavoriteGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGenres_Users_UsersByGenreId",
                        column: x => x.UsersByGenreId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGenres_UsersByGenreId",
                table: "UserGenres",
                column: "UsersByGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovies_Users_UserId",
                table: "PurchasedMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedMovies_Users_UserId",
                table: "PurchasedMovies");

            migrationBuilder.DropTable(
                name: "UserGenres");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PurchasedMovies",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedMovies_UserId",
                table: "PurchasedMovies",
                newName: "IX_PurchasedMovies_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGenres",
                columns: table => new
                {
                    CustomersByGenreId = table.Column<long>(type: "bigint", nullable: false),
                    FavoriteGenresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGenres", x => new { x.CustomersByGenreId, x.FavoriteGenresId });
                    table.ForeignKey(
                        name: "FK_CustomerGenres_Customers_CustomersByGenreId",
                        column: x => x.CustomersByGenreId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGenres_Genres_FavoriteGenresId",
                        column: x => x.FavoriteGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGenres_FavoriteGenresId",
                table: "CustomerGenres",
                column: "FavoriteGenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedMovies_Customers_CustomerId",
                table: "PurchasedMovies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
