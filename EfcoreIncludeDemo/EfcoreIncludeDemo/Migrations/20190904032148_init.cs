using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfcoreIncludeDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Model1S",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model1S", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model4S",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model4S", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model3S",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    Model4Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model3S", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model3S_Model4S_Model4Id",
                        column: x => x.Model4Id,
                        principalTable: "Model4S",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Model2S",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    Model3Id = table.Column<int>(nullable: true),
                    Model1Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model2S", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model2S_Model1S_Model1Id",
                        column: x => x.Model1Id,
                        principalTable: "Model1S",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Model2S_Model3S_Model3Id",
                        column: x => x.Model3Id,
                        principalTable: "Model3S",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model2S_Model1Id",
                table: "Model2S",
                column: "Model1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Model2S_Model3Id",
                table: "Model2S",
                column: "Model3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Model3S_Model4Id",
                table: "Model3S",
                column: "Model4Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Model2S");

            migrationBuilder.DropTable(
                name: "Model1S");

            migrationBuilder.DropTable(
                name: "Model3S");

            migrationBuilder.DropTable(
                name: "Model4S");
        }
    }
}
