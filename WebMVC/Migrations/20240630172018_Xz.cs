using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Xz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammarContents_GrammarTopics_GrammarTopicId",
                table: "GrammarContents");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_TestQuestions_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_GrammarTopics_GrammarTopicId",
                table: "TestQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedAnswer",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GrammarTopicId",
                table: "TestQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "TestAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GrammarTopics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GrammarTopics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrammarTopicId",
                table: "GrammarContents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContentText",
                table: "GrammarContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GrammarContents_GrammarTopics_GrammarTopicId",
                table: "GrammarContents",
                column: "GrammarTopicId",
                principalTable: "GrammarTopics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_TestQuestions_QuestionId",
                table: "TestAnswers",
                column: "QuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_GrammarTopics_GrammarTopicId",
                table: "TestQuestions",
                column: "GrammarTopicId",
                principalTable: "GrammarTopics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammarContents_GrammarTopics_GrammarTopicId",
                table: "GrammarContents");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_TestQuestions_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_GrammarTopics_GrammarTopicId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GrammarTopics");

            migrationBuilder.DropColumn(
                name: "ContentText",
                table: "GrammarContents");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedAnswer",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrammarTopicId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "TestAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GrammarTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrammarTopicId",
                table: "GrammarContents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GrammarContents_GrammarTopics_GrammarTopicId",
                table: "GrammarContents",
                column: "GrammarTopicId",
                principalTable: "GrammarTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
