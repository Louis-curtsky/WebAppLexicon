using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppLexicon.Migrations
{
    public partial class DbCreateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    UserRolesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CntyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CntyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CntyId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCats",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categories = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCats", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: true),
                    CntyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Countries_CntyId",
                        column: x => x.CntyId,
                        principalTable: "Countries",
                        principalColumn: "CntyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberType = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GovIdType = table.Column<string>(nullable: true),
                    GovId = table.Column<string>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CtyId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CntyId = table.Column<int>(nullable: false),
                    LangRead1 = table.Column<int>(nullable: false),
                    LangWrite1 = table.Column<int>(nullable: false),
                    MemberApproval = table.Column<string>(nullable: true),
                    MemberDate = table.Column<DateTime>(nullable: false),
                    CountryCntyId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Countries_CountryCntyId",
                        column: x => x.CountryCntyId,
                        principalTable: "Countries",
                        principalColumn: "CntyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberLanguages",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MLId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLanguages", x => new { x.MemberId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MemberLanguages_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLanguages_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    SkillDesc = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<int>(nullable: false),
                    SkillYears = table.Column<int>(nullable: false),
                    Charges = table.Column<int>(nullable: false),
                    ChargeUnit = table.Column<string>(nullable: true),
                    MinUnit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => new { x.MemberId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_Skills_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_SkillCats_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SkillCats",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDesc = table.Column<string>(nullable: true),
                    SkillId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    JobComments = table.Column<string>(nullable: true),
                    SkillsMemberId = table.Column<int>(nullable: true),
                    SkillsSkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Skills_SkillsMemberId_SkillsSkillId",
                        columns: x => new { x.SkillsMemberId, x.SkillsSkillId },
                        principalTable: "Skills",
                        principalColumns: new[] { "MemberId", "SkillId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3315e586-b15e-4638-b10b-066af33a977b", "3315e586-b15e-4638-b10b-066af33a977b", "SuperAdmin", "SuperAdmin" },
                    { "12af27d9-4eb2-4501-8efa-349114e125ca", "12af27d9-4eb2-4501-8efa-349114e125ca", "Admin", "Admin" },
                    { "c6c8a915-cddb-4e22-b8c5-470af487e503", "c6c8a915-cddb-4e22-b8c5-470af487e503", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "MemberId", "UserRolesId" },
                values: new object[,]
                {
                    { "90fa7ed2-e4c2-4bd8-8cca-88393053238a", 0, "dbc3134e-212f-48ad-8185-4505072b80b1", "AppUser", "admin@gmail.com", true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENuDSOussH39MPoIWG0RtVByF/IuKszgrkRN4grQ0f0NzOD4dT0zFd44Fa1lytqjBQ==", null, false, "f7a6d11e-4fbe-42dc-8ac0-7848142d43de", false, "Admin", "Vicient", "Hook", 9998, "12af27d9-4eb2-4501-8efa-349114e125ca" },
                    { "886ccb26-8207-47b7-8013-bdc8c69e3561", 0, "be58153e-6280-49a8-8789-993dd5e46f6b", "AppUser", "superadmin@gmail.com", true, false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEGpp0baZQVujf08kAXoH4QeNcg8Dc9B3j/QkLjnzgZaAtyElDTsZOMuPR7JZevmiuA==", null, false, "096bb9a8-f45a-4017-bb22-1625cec44eb7", false, "SuperAdmin", "Louis", "Lim", 9999, "3315e586-b15e-4638-b10b-066af33a977b" },
                    { "d210e5d3-ccbd-4807-8639-90666c19db59", 0, "bf5eb466-87bf-41ce-b872-4fe69d02690e", "AppUser", "user1@gmail.com", true, false, null, null, "USER1", "AQAAAAEAACcQAAAAEAQndneECzuLur+RwWXbwSH0UZeOdFVG0X+aBIQTSp23EXIdoe6+OVhei3Yv4pBAeQ==", null, false, "1023e3e5-78a5-4e96-bae4-9b8cb80e0940", false, "User1", "Vicient", "Kent", 0, "c6c8a915-cddb-4e22-b8c5-470af487e503" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CntyId", "CntyName" },
                values: new object[,]
                {
                    { 4, "Germany" },
                    { 2, "France" },
                    { 1, "Sweden" },
                    { 3, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "LangName" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "English" },
                    { 3, "French" },
                    { 4, "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "SkillCats",
                columns: new[] { "SkillId", "Categories" },
                values: new object[,]
                {
                    { 9, "Simple Cooking" },
                    { 13, "Panio" },
                    { 12, "Magic Show for Kids" },
                    { 11, "House Party Decoration" },
                    { 10, "Baking" },
                    { 8, "Lundary" },
                    { 1, "Cleaning" },
                    { 6, "Baby Sitting" },
                    { 5, "Pets Care" },
                    { 4, "Car washing" },
                    { 3, "Carpentry" },
                    { 2, "Moving" },
                    { 14, "Teach Panio" },
                    { 7, "Story telling" },
                    { 999, "Others" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "886ccb26-8207-47b7-8013-bdc8c69e3561", "3315e586-b15e-4638-b10b-066af33a977b" },
                    { "90fa7ed2-e4c2-4bd8-8cca-88393053238a", "12af27d9-4eb2-4501-8efa-349114e125ca" },
                    { "d210e5d3-ccbd-4807-8639-90666c19db59", "c6c8a915-cddb-4e22-b8c5-470af487e503" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "StateId", "CntyId", "StateName" },
                values: new object[,]
                {
                    { 1, 1, "Kronoberg" },
                    { 2, 1, "Skåne" },
                    { 3, 1, "Uppsala" },
                    { 4, 1, "Gäveborg" },
                    { 5, 1, "Stockholm" },
                    { 6, 1, "Gotland" },
                    { 11, 2, "Île‑de‑France" },
                    { 10, 3, "Lazio" },
                    { 7, 4, "Berlin" },
                    { 8, 4, "Bavaria" },
                    { 9, 4, "Hamburg" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "StateId" },
                values: new object[,]
                {
                    { 3, "Växjö", 1 },
                    { 7, "Hamburg", 9 },
                    { 8, "Munich", 8 },
                    { 6, "Berlin", 7 },
                    { 10, "Rome", 10 },
                    { 5, "Visby", 6 },
                    { 1, "Stockholm", 5 },
                    { 4, "Gävle", 4 },
                    { 11, "Paris", 11 },
                    { 9, "Lund", 2 },
                    { 2, "Helsingborg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Age", "CityId", "CntyId", "CountryCntyId", "CtyId", "Email", "FirstName", "Gender", "GovId", "GovIdType", "LangRead1", "LangWrite1", "LastName", "LoginId", "LoginName", "MemberApproval", "MemberDate", "MemberType", "Nationality", "Phone", "StateId" },
                values: new object[,]
                {
                    { 12, 18, null, 1, null, 2, "kmonganb@1und1.de", "Kingsly", "Male", null, null, 0, 0, "Mongan", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yaqui", "805-257-2819", 2 },
                    { 14, 32, null, 4, null, 7, "aknotted@apache.org", "Abbie", "Male", null, null, 0, 0, "Knotte", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Argentinian", "870-289-5196", 9 },
                    { 1, 30, null, 1, null, 3, "ggurnay0@opera.com", "Giustina", "Genderfluid", null, null, 0, 0, "Gurnay", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Panamanian", "108-553-0832", 1 },
                    { 6, 35, null, 4, null, 7, "tvelte5@nps.gov", "Tommie", "Male", null, null, 0, 0, "Velte", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Filipino", "474-732-2163", 8 },
                    { 2, 76, null, 4, null, 7, "dkissick1@clickbank.net", "Danita", "Female", null, null, 0, 0, "Kissick", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iroquois", "102-688-4545", 8 },
                    { 3, 35, null, 1, null, 3, "cnoice2@wisc.edu", "Creigh", "Male", null, null, 0, 0, "Noice", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shoshone", "934-181-5000", 1 },
                    { 7, 40, null, 1, null, 3, "dgonzales6@yelp.com", "Dennison", "Male", null, null, 0, 0, "Gonzales", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Puerto Rican", "706-580-3696", 1 },
                    { 20, 46, null, 3, null, 10, "clessliej@boston.com", "Cecilia", "Female", null, null, 0, 0, "Lesslie", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tongan", "358-511-7422", 10 },
                    { 8, 56, null, 3, null, 10, "tmorphet7@wix.com", "Tynan", "Non-binary", null, null, 0, 0, "Morphet", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "White", "298-108-6587", 10 },
                    { 16, 71, null, 1, null, 3, "abufferyf@jalbum.net", "Amber", "Female", null, null, 0, 0, "Buffery", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chilean", "716-926-5332", 1 },
                    { 10, 49, null, 1, null, 9, "lolczak9@spiegel.de", "Lisa", "Female", null, null, 0, 0, "Olczak", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vietnamese", "225-320-9656", 2 },
                    { 13, 55, null, 2, null, 11, "sortellsc@yelp.com", "Sayer", "Male", null, null, 0, 0, "Ortells", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Honduran", "201-214-9764", 11 },
                    { 11, 38, null, 2, null, 11, "rgenningsa@bloglines.com", "Rancell", "Genderfluid", null, null, 0, 0, "Gennings", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tlingit-Haida", "594-235-3927", 11 },
                    { 9, 33, null, 2, null, 11, "mfoulstone8@narod.ru", "Mischa", "Male", null, null, 0, 0, "Foulstone", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Menominee", "853-913-7659", 11 },
                    { 15, 90, null, 4, null, 7, "vputtrelle@nytimes.com", "Vilma", "Polygender", null, null, 0, 0, "Puttrell", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laotian", "176-399-0215", 9 },
                    { 17, 64, null, 1, null, 4, "wcolletg@a8.net", "Wiatt", "Male", null, null, 0, 0, "Collet", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chilean", "369-361-2111", 4 },
                    { 5, 62, null, 1, null, 2, "anattriss4@baidu.com", "Ariel", "Male", null, null, 0, 0, "Nattriss", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chickasaw", "662-951-7611", 2 },
                    { 18, 18, null, 1, null, 9, "cgilstinh@ucla.edu", "Cacilia", "Female", null, null, 0, 0, "Gilstin", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cree", "582-143-5937", 2 },
                    { 4, 67, null, 3, null, 10, "dhourihane3@toplist.cz", "Denis", "Male", null, null, 0, 0, "Hourihane", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "American Indian and Alaska Native (AIAN)", "260-684-7945", 10 },
                    { 19, 53, null, 4, null, 7, "lzecchiii@domainmarket.com", "Libbie", "Female", null, null, 0, 0, "Zecchii", null, null, "P", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paiute", "529-137-4269", 9 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "MemberId", "SkillId", "ChargeUnit", "Charges", "ID", "MinUnit", "SkillDesc", "SkillLevel", "SkillYears" },
                values: new object[,]
                {
                    { 3, 2, null, 0, 2, 0, null, 3, 1 },
                    { 7, 2, null, 0, 7, 0, null, 3, 4 },
                    { 7, 10, null, 0, 10, 0, null, 2, 2 },
                    { 9, 1, null, 0, 1, 0, null, 2, 2 },
                    { 11, 6, null, 0, 6, 0, null, 3, 9 },
                    { 13, 3, null, 0, 3, 0, null, 1, 7 },
                    { 6, 3, null, 0, 9, 0, null, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SkillsMemberId_SkillsSkillId",
                table: "Jobs",
                columns: new[] { "SkillsMemberId", "SkillsSkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_MemberLanguages_LanguageId",
                table: "MemberLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CityId",
                table: "Members",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CountryCntyId",
                table: "Members",
                column: "CountryCntyId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_StateId",
                table: "Members",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillId",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CntyId",
                table: "State",
                column: "CntyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "MemberLanguages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SkillCats");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
