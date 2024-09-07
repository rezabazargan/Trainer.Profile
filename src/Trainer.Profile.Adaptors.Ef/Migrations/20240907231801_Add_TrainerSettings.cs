using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainer.Profile.Adaptors.Ef.Migrations
{
    /// <inheritdoc />
    public partial class Add_TrainerSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "profile",
                table: "Trainer",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "profile",
                table: "Trainer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerSettingsId",
                schema: "profile",
                table: "Trainer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainerSettings",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerSettings_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalSchema: "profile",
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_TrainerSettingsId",
                schema: "profile",
                table: "Trainer",
                column: "TrainerSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSettings_TrainerId",
                schema: "profile",
                table: "TrainerSettings",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainer_TrainerSettings_TrainerSettingsId",
                schema: "profile",
                table: "Trainer",
                column: "TrainerSettingsId",
                principalSchema: "profile",
                principalTable: "TrainerSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainer_TrainerSettings_TrainerSettingsId",
                schema: "profile",
                table: "Trainer");

            migrationBuilder.DropTable(
                name: "TrainerSettings",
                schema: "profile");

            migrationBuilder.DropIndex(
                name: "IX_Trainer_TrainerSettingsId",
                schema: "profile",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "TrainerSettingsId",
                schema: "profile",
                table: "Trainer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "profile",
                table: "Trainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "profile",
                table: "Trainer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
