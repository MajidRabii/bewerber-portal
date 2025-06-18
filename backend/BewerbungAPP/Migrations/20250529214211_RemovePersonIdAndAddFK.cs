using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BewerbungAPP.Migrations
{
    /// <inheritdoc />
    public partial class RemovePersonIdAndAddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "profil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "profil",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
