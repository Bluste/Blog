using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBlog.Migrations
{
    /// <inheritdoc />
    public partial class updatedValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddff9edf-57c0-45b9-82b7-4648edd98228");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd", 0, "649f313e-ec6d-4851-ac0b-9a075dec0110", "ApplicationUser", "testuser@example.com", true, false, null, "TESTUSER@EXAMPLE.COM", "TESTUSER", "AQAAAAEAACcQAAAAEFe/f9+27rbfF68RzZlQ1VNm/U4QxkCuB9sSO1vScxF5npGHlfc4U4FZPA9Zj65+Gg==", null, false, "e2b4c5b9-c914-4db0-aaae-4e6b83dfea42", false, "testuser" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(7705), "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd", new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(7941) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(8725), "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd", new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(8734) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 16, 13, 187, DateTimeKind.Local).AddTicks(7985), "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd", new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(6660), "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd", new DateTime(2025, 1, 3, 12, 16, 13, 189, DateTimeKind.Local).AddTicks(6671) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddff9edf-57c0-45b9-82b7-4648edd98228", 0, "3d3800cc-14e6-477e-8a86-bfa0c1d3c87a", "ApplicationUser", "testuser@example.com", true, false, null, "TESTUSER@EXAMPLE.COM", "TESTUSER", "AQAAAAEAACcQAAAAEFe/f9+27rbfF68RzZlQ1VNm/U4QxkCuB9sSO1vScxF5npGHlfc4U4FZPA9Zj65+Gg==", null, false, "cb0b2f6a-495e-45e5-a70c-ad93323317ee", false, "testuser" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(2854), "ddff9edf-57c0-45b9-82b7-4648edd98228", new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(3901), "ddff9edf-57c0-45b9-82b7-4648edd98228", new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 16, 56, 580, DateTimeKind.Local).AddTicks(2275), "ddff9edf-57c0-45b9-82b7-4648edd98228", new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(1578), "ddff9edf-57c0-45b9-82b7-4648edd98228", new DateTime(2025, 1, 3, 3, 16, 56, 582, DateTimeKind.Local).AddTicks(1588) });
        }
    }
}
