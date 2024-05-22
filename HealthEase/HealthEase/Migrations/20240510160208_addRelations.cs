using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthEase.Migrations
{
    /// <inheritdoc />
    public partial class addRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appointment");
        }
    }
}
