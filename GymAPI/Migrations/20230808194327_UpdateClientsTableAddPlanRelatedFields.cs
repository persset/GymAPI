using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymAPI.Migrations
{
    public partial class UpdateClientsTableAddPlanRelatedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionDeadline",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PlanId",
                table: "Clients",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Plans_PlanId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PlanId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SubscriptionDeadline",
                table: "Clients");
        }
    }
}
