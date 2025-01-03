using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBlog.Migrations
{
    /// <inheritdoc />
    public partial class cleanStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4f7d30e-f1df-4fd2-b0a9-fe34aca186fd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e1fad1a-cd19-4cd5-8e96-07fd35359ace", 0, "f5353d7f-2590-4413-b322-755bb17bf67b", "ApplicationUser", "testuser@example.com", true, false, null, "TESTUSER@EXAMPLE.COM", "TESTUSER", "AQAAAAEAACcQAAAAEFe/f9+27rbfF68RzZlQ1VNm/U4QxkCuB9sSO1vScxF5npGHlfc4U4FZPA9Zj65+Gg==", null, false, "1c608a9b-6cfe-4251-9c66-27d78f2fb9b6", false, "testuser" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(1049), "2e1fad1a-cd19-4cd5-8e96-07fd35359ace", new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(2092), "2e1fad1a-cd19-4cd5-8e96-07fd35359ace", new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 23, 24, 591, DateTimeKind.Local).AddTicks(1573), "2e1fad1a-cd19-4cd5-8e96-07fd35359ace", new DateTime(2025, 1, 3, 12, 23, 24, 592, DateTimeKind.Local).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create_At", "IdentityUserId", "Update_At" },
                values: new object[] { new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(64), "2e1fad1a-cd19-4cd5-8e96-07fd35359ace", new DateTime(2025, 1, 3, 12, 23, 24, 593, DateTimeKind.Local).AddTicks(75) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e1fad1a-cd19-4cd5-8e96-07fd35359ace");

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
    }
}
