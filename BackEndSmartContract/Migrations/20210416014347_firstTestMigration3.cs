using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndSmartContract.Migrations
{
    public partial class firstTestMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PersonalID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Surname = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    WalletAdress = table.Column<string>(type: "NVARCHAR(42)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealStates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentFee = table.Column<int>(type: "int", nullable: false),
                    RentDurationDays = table.Column<int>(type: "int", nullable: false),
                    RentPaymentSchedule = table.Column<int>(type: "int", nullable: false),
                    SqMtrs = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambientes = table.Column<int>(type: "int", nullable: false),
                    BedRoomQty = table.Column<int>(type: "int", nullable: false),
                    BathRoomQty = table.Column<int>(type: "int", nullable: false),
                    Garage = table.Column<bool>(type: "bit", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealStates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealStates_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealStates_userID",
                table: "RealStates",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealStates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
