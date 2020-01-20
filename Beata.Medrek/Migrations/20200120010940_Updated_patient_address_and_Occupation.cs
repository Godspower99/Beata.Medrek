using Microsoft.EntityFrameworkCore.Migrations;

namespace Beata.Medrek.Migrations
{
    public partial class Updated_patient_address_and_Occupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryAddress",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SecondaryAddress",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "PatientPhones",
                newName: "EmailAddress");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Patients",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Patients",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "PatientOriginOfBirth",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "PatientOriginOfBirth",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PatientOriginOfBirth",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "PatientAddress",
                columns: table => new
                {
                    MedRekNO = table.Column<string>(nullable: false),
                    PrimaryAddress = table.Column<string>(maxLength: 255, nullable: false),
                    SecondaryAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddress", x => x.MedRekNO);
                    table.ForeignKey(
                        name: "FK_PatientAddress_Patients_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patients",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAddress");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "PatientPhones",
                newName: "emailAddress");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Patients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddress",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAddress",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "PatientOriginOfBirth",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "PatientOriginOfBirth",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PatientOriginOfBirth",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
