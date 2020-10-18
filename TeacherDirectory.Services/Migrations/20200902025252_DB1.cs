using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherDirectory.Services.Migrations
{
    public partial class DB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Photopath = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false)
                }, //I used the the Packet manager to create this DB that is found in SQL
                //This code allows the teachers in the DB to be created, updated or deleted
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
