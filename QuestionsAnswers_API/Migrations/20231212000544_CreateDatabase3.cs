using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuestionsAnswers_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionVotes = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerVotes = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.VoteId);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Creationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Creationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_QuestionTag_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Creationdate", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9615), "This is the first question?" },
                    { 2, new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9631), "This is the second question?" }
                });

            migrationBuilder.InsertData(
                table: "Vote",
                columns: new[] { "VoteId", "AnswerId", "AnswerVotes", "QuestionId", "QuestionVotes" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 3 },
                    { 2, 2, 1, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "Creationdate", "Description", "QuestionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9821), "This is the first answer for question 1?", 1 },
                    { 2, new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9823), "This is the second answer for question 2?", 2 }
                });

            migrationBuilder.InsertData(
                table: "QuestionTag",
                columns: new[] { "TagId", "Creationdate", "QuestionId", "TagDescription" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 11, 18, 5, 44, 207, DateTimeKind.Local).AddTicks(9219), 1, "Tag1" },
                    { 2, new DateTime(2023, 12, 11, 18, 5, 44, 207, DateTimeKind.Local).AddTicks(9230), 2, "Tag2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTag_QuestionId",
                table: "QuestionTag",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionTag");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
