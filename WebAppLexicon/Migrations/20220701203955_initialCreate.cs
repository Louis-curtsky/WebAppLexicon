using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppLexicon.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CntyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CntyId", "CntyName" },
                values: new object[,]
                {
                    { 1, "Sweden" },
                    { 2, "France" },
                    { 3, "Italy" },
                    { 4, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "StateId", "CountryId", "StateName" },
                values: new object[,]
                {
                    { 1, 1, "Kronoberg" },
                    { 2, 1, "Skåne" },
                    { 3, 1, "Uppsala" },
                    { 4, 1, "Gäveborg" },
                    { 5, 1, "Stockholm" },
                    { 6, 1, "Gotland" },
                    { 7, 3, "Berlin" },
                    { 8, 3, "Bavaria" },
                    { 9, 3, "Hamburg" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "StateId" },
                values: new object[,]
                {
                    { 3, "Växjö", 1 },
                    { 2, "Helsingborg", 2 },
                    { 4, "Gävle", 4 },
                    { 1, "Stockholm", 5 },
                    { 5, "Visby", 6 },
                    { 6, "Berlin", 7 },
                    { 8, "Munich", 8 },
                    { 7, "Hamburg", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
