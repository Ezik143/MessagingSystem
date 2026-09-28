using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessagingSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRelationshipsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatParticipants_Users_UserId",
                table: "ChatParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_CreatorId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_CreatorId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_ReadReceipts_UserId",
                table: "ReadReceipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CreatedBy",
                table: "Chats",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatParticipants_Users_UserId",
                table: "ChatParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_CreatedBy",
                table: "Chats",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadReceipts_Users_UserId",
                table: "ReadReceipts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatParticipants_Users_UserId",
                table: "ChatParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_CreatedBy",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadReceipts_Users_UserId",
                table: "ReadReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ReadReceipts_UserId",
                table: "ReadReceipts");

            migrationBuilder.DropIndex(
                name: "IX_Chats_CreatedBy",
                table: "Chats");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Chats",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CreatorId",
                table: "Chats",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatParticipants_Users_UserId",
                table: "ChatParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_CreatorId",
                table: "Chats",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
