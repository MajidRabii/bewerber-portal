using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BewerbungAPP.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deutsch",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Einsatzwunsch",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Englisch",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Fuehrerschein",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Persisch",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Zertifikate",
                table: "profil");

            migrationBuilder.RenameColumn(
                name: "Anto",
                table: "profil",
                newName: "Auto");

            migrationBuilder.AddColumn<short>(
                name: "Deutsch_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Einsatzwunsch_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Englisch_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Fuehrerschein_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Niveau_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Persisch_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Zertifikate_Id",
                table: "profil",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deutsch_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Einsatzwunsch_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Englisch_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Fuehrerschein_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Niveau_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Persisch_Id",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Zertifikate_Id",
                table: "profil");

            migrationBuilder.RenameColumn(
                name: "Auto",
                table: "profil",
                newName: "Anto");

            migrationBuilder.AddColumn<string>(
                name: "Deutsch",
                table: "profil",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "Anfänger");

            migrationBuilder.AddColumn<string>(
                name: "Einsatzwunsch",
                table: "profil",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "Vollzeit");

            migrationBuilder.AddColumn<string>(
                name: "Englisch",
                table: "profil",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "Anfänger");

            migrationBuilder.AddColumn<string>(
                name: "Fuehrerschein",
                table: "profil",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "Nein");

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "profil",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "Nein");

            migrationBuilder.AddColumn<string>(
                name: "Persisch",
                table: "profil",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "Muttersprache");

            migrationBuilder.AddColumn<string>(
                name: "Zertifikate",
                table: "profil",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "Nein");
        }
    }
}
