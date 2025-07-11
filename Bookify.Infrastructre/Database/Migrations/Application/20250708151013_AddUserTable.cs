﻿// <auto-generated />

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructre.Database.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fK_bookings_user_userId",
                schema: "Application",
                table: "bookings");

            migrationBuilder.DropPrimaryKey(
                name: "pK_user",
                schema: "Application",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "Application",
                newName: "users",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "iX_user_email",
                schema: "Application",
                table: "users",
                newName: "iX_users_email");

            migrationBuilder.AddPrimaryKey(
                name: "pK_users",
                schema: "Application",
                table: "users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fK_bookings_users_userId",
                schema: "Application",
                table: "bookings",
                column: "userId",
                principalSchema: "Application",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fK_bookings_users_userId",
                schema: "Application",
                table: "bookings");

            migrationBuilder.DropPrimaryKey(
                name: "pK_users",
                schema: "Application",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "Application",
                newName: "user",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "iX_users_email",
                schema: "Application",
                table: "user",
                newName: "iX_user_email");

            migrationBuilder.AddPrimaryKey(
                name: "pK_user",
                schema: "Application",
                table: "user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fK_bookings_user_userId",
                schema: "Application",
                table: "bookings",
                column: "userId",
                principalSchema: "Application",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
