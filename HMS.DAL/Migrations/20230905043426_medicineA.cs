using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class medicineA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenericName",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SellQuantity",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicineGenericID",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineGeneric",
                columns: table => new
                {
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineGenericNames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGeneric", x => x.MedicineGenericID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID",
                principalTable: "MedicineGeneric",
                principalColumn: "MedicineGenericID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "MedicineGeneric");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Medicines");

            migrationBuilder.AddColumn<string>(
                name: "GenericName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellQuantity",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
