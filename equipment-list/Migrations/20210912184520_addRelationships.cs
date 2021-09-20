using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace equipment_list.Migrations
{
    public partial class addRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decommissions_Employees_EmployeeId",
                table: "Decommissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Decommissions_Equipments_EquipmentId",
                table: "Decommissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_EmployeeIdId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EmployeeIdId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EmployeeIdId",
                table: "Equipments");

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentId",
                table: "Decommissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Decommissions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DecommissionId",
                table: "Equipments",
                column: "DecommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EmployeeId",
                table: "Equipments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decommissions_Employees_EmployeeId",
                table: "Decommissions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Decommissions_Equipments_EquipmentId",
                table: "Decommissions",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Decommissions_DecommissionId",
                table: "Equipments",
                column: "DecommissionId",
                principalTable: "Decommissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_EmployeeId",
                table: "Equipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decommissions_Employees_EmployeeId",
                table: "Decommissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Decommissions_Equipments_EquipmentId",
                table: "Decommissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Decommissions_DecommissionId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Employees_EmployeeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_DecommissionId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EmployeeId",
                table: "Equipments");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeIdId",
                table: "Equipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentId",
                table: "Decommissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Decommissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EmployeeIdId",
                table: "Equipments",
                column: "EmployeeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decommissions_Employees_EmployeeId",
                table: "Decommissions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decommissions_Equipments_EquipmentId",
                table: "Decommissions",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Employees_EmployeeIdId",
                table: "Equipments",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
