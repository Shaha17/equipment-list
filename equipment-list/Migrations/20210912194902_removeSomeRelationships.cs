using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace equipment_list.Migrations
{
    public partial class removeSomeRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Decommissions_DecommissionId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_DecommissionId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "DecommissionId",
                table: "Equipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DecommissionId",
                table: "Equipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DecommissionId",
                table: "Equipments",
                column: "DecommissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Decommissions_DecommissionId",
                table: "Equipments",
                column: "DecommissionId",
                principalTable: "Decommissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
