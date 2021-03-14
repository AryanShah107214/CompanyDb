using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyDb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleID = table.Column<int>(nullable: false),
                    ItemName = table.Column<int>(maxLength: 50, nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    StoreID = table.Column<int>(nullable: false),
                    ItemCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sale_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreID = table.Column<string>(nullable: false),
                    StoreLocation = table.Column<string>(nullable: true),
                    ItemCost = table.Column<decimal>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    SaleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreID);
                    table.ForeignKey(
                        name: "FK_Store_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Sale_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sale",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    StoreID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Store_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Store",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentStore",
                columns: table => new
                {
                    DepartmentStoreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(nullable: false),
                    StoreID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStore", x => x.DepartmentStoreID);
                    table.ForeignKey(
                        name: "FK_DepartmentStore_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentStore_Store_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Store",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_StoreID",
                table: "Department",
                column: "StoreID",
                unique: true,
                filter: "[StoreID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStore_DepartmentID",
                table: "DepartmentStore",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStore_StoreID",
                table: "DepartmentStore",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_EmployeeID",
                table: "Sale",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_EmployeeID",
                table: "Store",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_SaleID",
                table: "Store",
                column: "SaleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentStore");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
