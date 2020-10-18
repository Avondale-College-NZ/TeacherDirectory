using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherDirectory.Services.Migrations
{
    public partial class spGetTeacherById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
             Create procedure spGetTeacherById
             @Id int
             as
             Begin
	            Select * from Teachers
	            where Id = @Id
             End";
            migrationBuilder.Sql(procedure);
        } //Stored procedure in the SQL DB that retreves the teacher by the ID

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetTeacherById";
            migrationBuilder.Sql(procedure);
        }
    }
}
