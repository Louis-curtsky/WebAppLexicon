using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppLexicon.Migrations
{
    public partial class DbCreateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRolesId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ebd84e1-2904-44e4-9e71-833b1cf3ab44", "6ebd84e1-2904-44e4-9e71-833b1cf3ab44", "SuperAdmin", "SuperAdmin" },
                    { "0c948f48-ae87-4f32-a2d4-d6d636351348", "0c948f48-ae87-4f32-a2d4-d6d636351348", "Admin", "Admin" },
                    { "e9aca773-8fc5-4c78-b8f1-5b96a0243839", "e9aca773-8fc5-4c78-b8f1-5b96a0243839", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "MemberId", "UserRolesId" },
                values: new object[,]
                {
                    { "d9c54bc7-3222-4b52-bded-acab826bd957", 0, "ea182049-e631-4368-827a-321ef60438b6", "AppUser", "superadmin@gmail.com", true, false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEKohWAmaOphMqLY4+Vbq6hmW/Y41+CqyQhggpawqe0+Lc/sxm109x/BYq3JIkOAbbA==", null, false, "87138a12-4135-40c8-90c4-12b2fb6719ae", false, "SuperAdmin", "Louis", "Lim", 9999, "6ebd84e1-2904-44e4-9e71-833b1cf3ab44" },
                    { "557760d8-e19b-4dcd-97ae-8187ffccdf7a", 0, "b7b5e1a2-c277-48b5-b464-321017fee71e", "AppUser", "admin@gmail.com", true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJsCSD75nE8UV6UtMIiR1/KsBaq9wlQRXpGyn7oUjXvRhwRwLwEfLCqhM2U8krjRBA==", null, false, "370c3ff3-37f9-4a1d-acfa-e292d82c28b0", false, "Admin", "Vicient", "Hook", 9998, "0c948f48-ae87-4f32-a2d4-d6d636351348" },
                    { "cb4b0c64-3ab5-4711-88f4-fd6ae9920070", 0, "a0ca0d8b-7df4-4c92-a72d-612e11f0a866", "AppUser", "user1@gmail.com", true, false, null, null, "USER1", "AQAAAAEAACcQAAAAEJgy26HaHKTJ3FdE99ei5ANmshYrO30v7SMY24BQBIIX7WbAhcjts8bHycnTple0Rg==", null, false, "376011fe-2d07-43b5-9d64-7ad556149aca", false, "User1", "Vicient", "Kent", 0, "e9aca773-8fc5-4c78-b8f1-5b96a0243839" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d9c54bc7-3222-4b52-bded-acab826bd957", "6ebd84e1-2904-44e4-9e71-833b1cf3ab44" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "557760d8-e19b-4dcd-97ae-8187ffccdf7a", "0c948f48-ae87-4f32-a2d4-d6d636351348" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "cb4b0c64-3ab5-4711-88f4-fd6ae9920070", "e9aca773-8fc5-4c78-b8f1-5b96a0243839" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "557760d8-e19b-4dcd-97ae-8187ffccdf7a", "0c948f48-ae87-4f32-a2d4-d6d636351348" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "cb4b0c64-3ab5-4711-88f4-fd6ae9920070", "e9aca773-8fc5-4c78-b8f1-5b96a0243839" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d9c54bc7-3222-4b52-bded-acab826bd957", "6ebd84e1-2904-44e4-9e71-833b1cf3ab44" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c948f48-ae87-4f32-a2d4-d6d636351348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ebd84e1-2904-44e4-9e71-833b1cf3ab44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9aca773-8fc5-4c78-b8f1-5b96a0243839");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "557760d8-e19b-4dcd-97ae-8187ffccdf7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb4b0c64-3ab5-4711-88f4-fd6ae9920070");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9c54bc7-3222-4b52-bded-acab826bd957");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRolesId",
                table: "AspNetUsers");
        }
    }
}
