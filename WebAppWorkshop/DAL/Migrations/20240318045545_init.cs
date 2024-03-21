using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppWorkshop.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receptionists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptionists", x => x.id);
                });

            migrationBuilder.CreateTable(
               name: "visitors",
               columns: table => new
               {
                   id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   phone = table.Column<string>(type: "nvarchar(max)", nullable: false)

               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_visitors", x => x.id);
               });

            migrationBuilder.CreateTable(
               name: "appointments",
               columns: table => new
               {
                   id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   receptionistID = table.Column<int>(type: "int", nullable: false),
                   visitorID = table.Column<int>(type: "int", nullable: false),
                   date = table.Column<DateOnly>(type: "date", nullable: false),
                   time = table.Column<TimeOnly>(type: "time", nullable: false),
                   purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   status = table.Column<string>(type: "nvarchar(max)", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_appointments", x => x.id);
                   table.ForeignKey(
                       name: "FK_appointments_receptionistID_receptionists_id",
                       column: x => x.receptionistID,
                       principalTable: "receptionists",
                       principalColumn: "id");
                   table.ForeignKey(
                       name: "FK_appointments_visitorID_visitors_id",
                       column: x => x.visitorID,
                       principalTable: "visitors",
                       principalColumn: "id");
               });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_receptionistID",
                table: "appointments",
                column: "receptionistID");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_visitorID",
                table: "appointments",
                column: "visitorID");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receptionists");

            migrationBuilder.DropTable(
                name: "visitors");

            migrationBuilder.DropTable(
              name: "appointments");
        }
    }
}
