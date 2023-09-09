using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class DocNurseModelchangeabdullah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTechnicians_Departments_DepartmentID",
                table: "LabTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians");

            migrationBuilder.DropColumn(
                name: "AttendanceDate",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "WorkShift",
                table: "LabTechnicians");

            migrationBuilder.DropColumn(
                name: "WorkShift",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "WorkShift",
                table: "OtherEmployees",
                newName: "OtherEmployeeType");

            migrationBuilder.RenameColumn(
                name: "EmployeePosition",
                table: "OtherEmployees",
                newName: "OtherEmployeeName");

            migrationBuilder.RenameColumn(
                name: "WorkShift",
                table: "Nurses",
                newName: "NurseType");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignDate",
                table: "OtherEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeStatus",
                table: "OtherEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignDate",
                table: "Nurses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeStatus",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignDate",
                table: "LabTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeStatus",
                table: "LabTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResignDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "doctortype",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "employeeStatus",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResignDate",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "employeeStatus",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "ResignDate",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "employeeStatus",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "ResignDate",
                table: "LabTechnicians");

            migrationBuilder.DropColumn(
                name: "employeeStatus",
                table: "LabTechnicians");

            migrationBuilder.DropColumn(
                name: "ResignDate",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "doctortype",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "employeeStatus",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "OtherEmployeeType",
                table: "OtherEmployees",
                newName: "WorkShift");

            migrationBuilder.RenameColumn(
                name: "OtherEmployeeName",
                table: "OtherEmployees",
                newName: "EmployeePosition");

            migrationBuilder.RenameColumn(
                name: "NurseType",
                table: "Nurses",
                newName: "WorkShift");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "OtherEmployees",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendanceDate",
                table: "OtherEmployees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Nurses",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "LabTechnicians",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "WorkShift",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Doctors",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "WorkShift",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTechnicians_Departments_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
