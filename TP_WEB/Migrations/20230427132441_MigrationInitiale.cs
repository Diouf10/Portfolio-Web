using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_WEB.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperienceProfessionnels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEntreprise = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PosteOccupe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionTaches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeEmbauche = table.Column<int>(type: "int", nullable: false),
                    AnneeFinEmploi = table.Column<int>(type: "int", nullable: true),
                    SiteEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceProfessionnels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormationAcademiques",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEcole = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProgrammeEtude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnneeDebutFormation = table.Column<int>(type: "int", nullable: false),
                    AnneeFinFormation = table.Column<int>(type: "int", nullable: false),
                    LienProgrammeEtude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstDiplomeObtenu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationAcademiques", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProjet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    TechnologieUtilise = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreHeure = table.Column<int>(type: "int", nullable: true),
                    AdresseWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleProjet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Afficher = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Portfolios_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ImageID",
                table: "Portfolios",
                column: "ImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceProfessionnels");

            migrationBuilder.DropTable(
                name: "FormationAcademiques");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
