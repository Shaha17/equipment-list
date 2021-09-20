using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace equipment_list.Migrations
{
    public partial class someChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_EmployeeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EmployeeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Equipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Equipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EmployeeId",
                table: "Equipments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_EmployeeId",
                table: "Equipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
