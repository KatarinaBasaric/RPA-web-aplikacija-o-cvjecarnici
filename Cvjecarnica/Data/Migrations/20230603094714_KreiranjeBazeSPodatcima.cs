using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cvjecarnica.Data.Migrations
{
    public partial class KreiranjeBazeSPodatcima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cvijece",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SlikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvijece", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cvijece_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Ruze" },
                    { 2, "Karanfili" },
                    { 3, "Orhideje" },
                    { 4, "Tulipani" },
                    { 5, "Ljiljani" }
                });

            migrationBuilder.InsertData(
                table: "Cvijece",
                columns: new[] { "Id", "Boja", "Cijena", "KategorijaId", "Naziv", "SlikaUrl" },
                values: new object[,]
                {
                    { 1, "Crvena", 3.50m, 1, "Ruze", "https://cvjecarnica-skrinjaric.hr/wp-content/uploads/2021/09/Crvena-ruza.jpg" },
                    { 2, "Ljubicasta", 3.00m, 2, "Karanfili", "https://cvecaralilies.rs/files/product_picture/115/lead_picture/2020.10.21.09.27.57_5f8fe2fd97b9f_KARANFIL_big.jpg" },
                    { 3, "Zuta", 5.00m, 3, "Orhideje", "https://anamarija.com.hr/Indigo-5pcs-%C5%BEuta-phalaenopsis-orhideja-7-boja-stabljika/3-pics_pictures/25667.jpg" },
                    { 4, "Bijela", 3.00m, 4, "Tulipani", "https://www.cvijetarkadija.hr/media/places/medium_2fdf392d-321f-461d-8407-4cc45e82311e.jpg" },
                    { 5, "Plavi", 5.00m, 5, "Ljiljani", "https://cvecaraelite.rs/wp-content/uploads/2020/02/26-zameni-slicku.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cvijece_KategorijaId",
                table: "Cvijece",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cvijece");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
