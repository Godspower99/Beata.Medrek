using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beata.Medrek.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    MedRekNO = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 25, nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    RegistrationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.MedRekNO);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    Middle = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    PrimaryPhone = table.Column<string>(maxLength: 15, nullable: false),
                    SecondaryPhone = table.Column<string>(maxLength: 15, nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "PatientFamilyContacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedRekNO = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 25, nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFamilyContacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientFamilyContacts_Patient_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patient",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientOriginOfBirths",
                columns: table => new
                {
                    MedRekNO = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 25, nullable: false),
                    State = table.Column<string>(maxLength: 25, nullable: false),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    LGA = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOriginOfBirths", x => x.MedRekNO);
                    table.ForeignKey(
                        name: "FK_PatientOriginOfBirths_Patient_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patient",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPhones",
                columns: table => new
                {
                    MedRekNO = table.Column<string>(nullable: false),
                    PrimaryPhone = table.Column<string>(maxLength: 15, nullable: false),
                    SecondaryPhone = table.Column<string>(maxLength: 15, nullable: true),
                    emailAddress = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPhones", x => x.MedRekNO);
                    table.ForeignKey(
                        name: "FK_PatientPhones_Patient_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patient",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsAddresses",
                columns: table => new
                {
                    MedRekNO = table.Column<string>(nullable: false),
                    PrimaryAddress = table.Column<string>(maxLength: 100, nullable: false),
                    SecondaryAddress = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsAddresses", x => x.MedRekNO);
                    table.ForeignKey(
                        name: "FK_PatientsAddresses_Patient_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patient",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsNotes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedRekNO = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    StaffUsername = table.Column<string>(maxLength: 25, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientsNotes_Patient_MedRekNO",
                        column: x => x.MedRekNO,
                        principalTable: "Patient",
                        principalColumn: "MedRekNO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientsNotes_Staffs_StaffUsername",
                        column: x => x.StaffUsername,
                        principalTable: "Staffs",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientFamilyContacts_MedRekNO",
                table: "PatientFamilyContacts",
                column: "MedRekNO");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsNotes_MedRekNO",
                table: "PatientsNotes",
                column: "MedRekNO");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsNotes_StaffUsername",
                table: "PatientsNotes",
                column: "StaffUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserName",
                table: "Staffs",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientFamilyContacts");

            migrationBuilder.DropTable(
                name: "PatientOriginOfBirths");

            migrationBuilder.DropTable(
                name: "PatientPhones");

            migrationBuilder.DropTable(
                name: "PatientsAddresses");

            migrationBuilder.DropTable(
                name: "PatientsNotes");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
