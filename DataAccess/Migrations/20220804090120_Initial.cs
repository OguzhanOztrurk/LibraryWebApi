using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    YearOfBirth = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Life = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsbnId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    NumberOfPages = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    BookSummary = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeExplanation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.BookAuthorId);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onloans",
                columns: table => new
                {
                    OnloanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    LendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    StateEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onloans", x => x.OnloanId);
                    table.ForeignKey(
                        name: "FK_Onloans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onloans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => new { x.BookId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_BookTypes_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Life", "Name", "Surname", "YearOfBirth" },
                values: new object[,]
                {
                    { 1, "Trabzonda doğdu ilk kitabı", "Ahmet", "Hamdi", "2002" },
                    { 2, "Trabzonda doğdu ilk kitabı", "Samet", "Uslu", "1987" },
                    { 3, "Trabzonda doğdu ilk kitabı", "Doğan", "Atalar", "1965" },
                    { 4, "Trabzonda doğdu ilk kitabı", "Cevher", "Küçük", "1980" },
                    { 5, "Trabzonda doğdu ilk kitabı", "Nafize", "Tezyürek", "1957" },
                    { 6, "Trabzonda doğdu ilk kitabı", "ceyhan", "Karslıoğlu", "1993" },
                    { 7, "Trabzonda doğdu ilk kitabı", "Yusuf", "Hacıoğlu", "1990" },
                    { 8, "Trabzonda doğdu ilk kitabı", "Ahmet", "Fazıl", "1986" },
                    { 9, "Trabzonda doğdu ilk kitabı", "selçuk", "Bulut", "1967" },
                    { 10, "Trabzonda doğdu ilk kitabı", "Arda", "Yılmaz", "1965" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookName", "BookSummary", "IsbnId", "NumberOfPages" },
                values: new object[,]
                {
                    { 1, "Küçükler", "Güzel bir kitap", 123456, "365" },
                    { 2, "Küçükler", "Güzel bir kitap", 126523, "365" },
                    { 3, "Küçükler", "Güzel bir kitap", 789653, "365" },
                    { 4, "Küçükler", "Güzel bir kitap", 986547, "365" },
                    { 5, "Küçükler", "Güzel bir kitap", 120365, "365" },
                    { 6, "Küçükler", "Güzel bir kitap", 986325, "365" },
                    { 7, "Küçükler", "Güzel bir kitap", 456378, "365" },
                    { 8, "Küçükler", "Güzel bir kitap", 986514, "365" },
                    { 9, "Küçükler", "Güzel bir kitap", 203654, "365" },
                    { 10, "Küçükler", "Güzel bir kitap", 745822, "365" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "Lastname", "Name", "isActive" },
                values: new object[,]
                {
                    { 1, "Trabzon", "Revi", "Ahmet", true },
                    { 2, "Trabzon", "Korkmaz", "Cemil", true },
                    { 3, "Trabzon", "Salihoğlu", "Ahmet", true },
                    { 4, "Trabzon", "Ağaoğlu", "Serkan", true },
                    { 5, "Trabzon", "Durak", "Zeynep", true },
                    { 6, "Trabzon", "Pınar", "Özgür", true },
                    { 7, "Trabzon", "Olgun", "Cemile", true },
                    { 8, "Trabzon", "Civelek", "Mehmet", true },
                    { 9, "Trabzon", "Akkaya", "Dursun", true },
                    { 10, "Trabzon", "Kurumlu", "Fazlı", true }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "TypeExplanation" },
                values: new object[,]
                {
                    { 1, "Polisiye" },
                    { 2, "Roman" },
                    { 3, "Masal" },
                    { 4, "Hikaye" },
                    { 5, "Tarih" },
                    { 6, "Ekonomi" },
                    { 7, "Genel Kültür" },
                    { 8, "Şiir" },
                    { 9, "Makale" },
                    { 10, "Sağlık" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookAuthorId", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 1 },
                    { 5, 2, 4 },
                    { 6, 2, 5 },
                    { 7, 3, 5 },
                    { 8, 3, 6 },
                    { 9, 4, 7 },
                    { 10, 5, 8 },
                    { 11, 6, 9 },
                    { 12, 7, 10 }
                });

            migrationBuilder.InsertData(
                table: "BookTypes",
                columns: new[] { "BookId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 8 },
                    { 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "Onloans",
                columns: new[] { "OnloanId", "BookId", "DeliveryTime", "LendingDate", "MemberId", "StateEnum" },
                values: new object[,]
                {
                    { 1, 1, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8012), 1, 0 },
                    { 2, 2, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8028), 2, 0 },
                    { 3, 3, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8030), 3, 0 },
                    { 4, 4, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8031), 4, 0 },
                    { 5, 5, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8033), 5, 0 },
                    { 6, 6, 15, new DateTime(2022, 8, 4, 12, 1, 19, 775, DateTimeKind.Local).AddTicks(8034), 8, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTypes_TypeId",
                table: "BookTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Onloans_BookId",
                table: "Onloans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Onloans_MemberId",
                table: "Onloans",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Onloans");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
