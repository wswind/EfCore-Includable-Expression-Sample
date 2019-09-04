using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfcoreIncludeDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Model1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataModel1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataModel3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model3s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataModel2 = table.Column<string>(nullable: true),
                    Model3Id = table.Column<int>(nullable: true),
                    Model1Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model2s_Model1s_Model1Id",
                        column: x => x.Model1Id,
                        principalTable: "Model1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Model2s_Model3s_Model3Id",
                        column: x => x.Model3Id,
                        principalTable: "Model3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Model2s_Model1Id",
                table: "Model2s",
                column: "Model1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Model2s_Model3Id",
                table: "Model2s",
                column: "Model3Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Model2s");

            migrationBuilder.DropTable(
                name: "Model1s");

            migrationBuilder.DropTable(
                name: "Model3s");
        }
    }
}
