using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class GrammarCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_TestQuestions_TestQuestionId",
                table: "TestAnswers");

            migrationBuilder.DropTable(
                name: "GrammarRules");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswers_TestQuestionId",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TestQuestionId",
                table: "TestAnswers");

            migrationBuilder.AddColumn<int>(
                name: "GrammarTopicId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GrammarTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrammarContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrammarTopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammarContents_GrammarTopics_GrammarTopicId",
                        column: x => x.GrammarTopicId,
                        principalTable: "GrammarTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_GrammarTopicId",
                table: "TestQuestions",
                column: "GrammarTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_QuestionId",
                table: "TestAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammarContents_GrammarTopicId",
                table: "GrammarContents",
                column: "GrammarTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_TestQuestions_QuestionId",
                table: "TestAnswers",
                column: "QuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_GrammarTopics_GrammarTopicId",
                table: "TestQuestions",
                column: "GrammarTopicId",
                principalTable: "GrammarTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_TestQuestions_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_GrammarTopics_GrammarTopicId",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "GrammarContents");

            migrationBuilder.DropTable(
                name: "GrammarTopics");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_GrammarTopicId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswers_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "GrammarTopicId",
                table: "TestQuestions");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TestQuestionId",
                table: "TestAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GrammarRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarRules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_TestQuestionId",
                table: "TestAnswers",
                column: "TestQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_TestQuestions_TestQuestionId",
                table: "TestAnswers",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id");
        }
    }
}
