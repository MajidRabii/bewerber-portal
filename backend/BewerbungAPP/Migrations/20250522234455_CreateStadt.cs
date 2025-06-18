using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BewerbungAPP.Migrations
{
    /// <inheritdoc />
    public partial class CreateStadt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stadt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Code = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bundesland = table.Column<string>(type: "varchar(100)", nullable: true),
                    Aktiv = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stadt", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stadt_Code",
                table: "stadt",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stadt");
        }
    }
}
