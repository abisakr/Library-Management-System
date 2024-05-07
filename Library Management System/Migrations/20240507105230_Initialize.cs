using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Books_BookId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_admin",
                table: "tbl_admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserTbl");

            migrationBuilder.RenameTable(
                name: "tbl_admin",
                newName: "AdminTbl");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentTbl");

            migrationBuilder.RenameTable(
                name: "StudentBooks",
                newName: "StudentBookTbl");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "BookTbl");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBooks_StudentId",
                table: "StudentBookTbl",
                newName: "IX_StudentBookTbl_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBooks_BookId",
                table: "StudentBookTbl",
                newName: "IX_StudentBookTbl_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "StudentTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTbl",
                table: "UserTbl",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminTbl",
                table: "AdminTbl",
                column: "AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTbl",
                table: "StudentTbl",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBookTbl",
                table: "StudentBookTbl",
                column: "StudentBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTbl",
                table: "BookTbl",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTbl_UserId",
                table: "StudentTbl",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBookTbl_BookTbl_BookId",
                table: "StudentBookTbl",
                column: "BookId",
                principalTable: "BookTbl",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBookTbl_StudentTbl_StudentId",
                table: "StudentBookTbl",
                column: "StudentId",
                principalTable: "StudentTbl",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTbl_UserTbl_UserId",
                table: "StudentTbl",
                column: "UserId",
                principalTable: "UserTbl",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBookTbl_BookTbl_BookId",
                table: "StudentBookTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBookTbl_StudentTbl_StudentId",
                table: "StudentBookTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTbl_UserTbl_UserId",
                table: "StudentTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTbl",
                table: "UserTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTbl",
                table: "StudentTbl");

            migrationBuilder.DropIndex(
                name: "IX_StudentTbl_UserId",
                table: "StudentTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBookTbl",
                table: "StudentBookTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTbl",
                table: "BookTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminTbl",
                table: "AdminTbl");

            migrationBuilder.RenameTable(
                name: "UserTbl",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "StudentTbl",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "StudentBookTbl",
                newName: "StudentBooks");

            migrationBuilder.RenameTable(
                name: "BookTbl",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "AdminTbl",
                newName: "tbl_admin");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBookTbl_StudentId",
                table: "StudentBooks",
                newName: "IX_StudentBooks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBookTbl_BookId",
                table: "StudentBooks",
                newName: "IX_StudentBooks_BookId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBooks",
                table: "StudentBooks",
                column: "StudentBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_admin",
                table: "tbl_admin",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Books_BookId",
                table: "StudentBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBooks_Students_StudentId",
                table: "StudentBooks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
