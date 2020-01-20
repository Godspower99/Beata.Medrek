using Microsoft.EntityFrameworkCore.Migrations;

namespace Beata.Medrek.Migrations
{
    public partial class CorrectStaffMiddleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientFamilyContacts_Patient_MedRekNO",
                table: "PatientFamilyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientOriginOfBirths_Patient_MedRekNO",
                table: "PatientOriginOfBirths");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientPhones_Patient_MedRekNO",
                table: "PatientPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsAddresses_Patient_MedRekNO",
                table: "PatientsAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsNotes_Patient_MedRekNO",
                table: "PatientsNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientOriginOfBirths",
                table: "PatientOriginOfBirths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Middle",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "PatientOriginOfBirths",
                newName: "PatientOriginOfBirth");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Staffs",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientOriginOfBirth",
                table: "PatientOriginOfBirth",
                column: "MedRekNO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "MedRekNO");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientFamilyContacts_Patients_MedRekNO",
                table: "PatientFamilyContacts",
                column: "MedRekNO",
                principalTable: "Patients",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientOriginOfBirth_Patients_MedRekNO",
                table: "PatientOriginOfBirth",
                column: "MedRekNO",
                principalTable: "Patients",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientPhones_Patients_MedRekNO",
                table: "PatientPhones",
                column: "MedRekNO",
                principalTable: "Patients",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsAddresses_Patients_MedRekNO",
                table: "PatientsAddresses",
                column: "MedRekNO",
                principalTable: "Patients",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsNotes_Patients_MedRekNO",
                table: "PatientsNotes",
                column: "MedRekNO",
                principalTable: "Patients",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientFamilyContacts_Patients_MedRekNO",
                table: "PatientFamilyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientOriginOfBirth_Patients_MedRekNO",
                table: "PatientOriginOfBirth");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientPhones_Patients_MedRekNO",
                table: "PatientPhones");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsAddresses_Patients_MedRekNO",
                table: "PatientsAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsNotes_Patients_MedRekNO",
                table: "PatientsNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientOriginOfBirth",
                table: "PatientOriginOfBirth");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "PatientOriginOfBirth",
                newName: "PatientOriginOfBirths");

            migrationBuilder.AddColumn<string>(
                name: "Middle",
                table: "Staffs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "MedRekNO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientOriginOfBirths",
                table: "PatientOriginOfBirths",
                column: "MedRekNO");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientFamilyContacts_Patient_MedRekNO",
                table: "PatientFamilyContacts",
                column: "MedRekNO",
                principalTable: "Patient",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientOriginOfBirths_Patient_MedRekNO",
                table: "PatientOriginOfBirths",
                column: "MedRekNO",
                principalTable: "Patient",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientPhones_Patient_MedRekNO",
                table: "PatientPhones",
                column: "MedRekNO",
                principalTable: "Patient",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsAddresses_Patient_MedRekNO",
                table: "PatientsAddresses",
                column: "MedRekNO",
                principalTable: "Patient",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsNotes_Patient_MedRekNO",
                table: "PatientsNotes",
                column: "MedRekNO",
                principalTable: "Patient",
                principalColumn: "MedRekNO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
