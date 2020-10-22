using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Presistance.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserIp = table.Column<string>(nullable: true),
                    UserInfo = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responds_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RespondId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Responds_RespondId",
                        column: x => x.RespondId,
                        principalTable: "Responds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 1, "m@m.com", "Admin", "123456" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreateDate", "Description", "IsActive", "IsRemoved", "Title", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Developer Roles", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "SurveyId", "Title" },
                values: new object[] { 1, null, 1, "Developer Type" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "SurveyId", "Title" },
                values: new object[] { 2, "Many developers work on code outside of work. About 78% of our respondents say that they code as a hobby. Other responsibilities outside of software can reduce developers' engagement in coding as a hobby; developers who say they have children or other caretaking responsibilities are less likely to code as a hobby. Respondents who are women are also less likely to say they code as a hobby.", 1, "Coding as a Hobby " });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "SurveyId", "Title" },
                values: new object[] { 3, "Experience", 1, "Years Since Learning to Code " });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Description", "QuestionId", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, "Developer, back-end" },
                    { 21, null, 1, "Senior executive/VP " },
                    { 22, null, 1, "Marketing or sales professional " },
                    { 23, null, 1, "Marketing or sales professional " },
                    { 24, null, 2, "Yes" },
                    { 25, null, 2, "No " },
                    { 26, null, 3, "Less than 5 years " },
                    { 20, null, 1, "Engineer, site reliability" },
                    { 27, null, 3, "5 to 9 years" },
                    { 29, null, 3, "15 to 19 years " },
                    { 30, null, 3, "20 to 24 years" },
                    { 31, null, 3, "25 to 29 years" },
                    { 32, null, 3, "30 to 34 years" },
                    { 33, null, 3, "35 to 39 years " },
                    { 34, null, 3, "40 to 44 years " },
                    { 28, null, 3, "10 to 14 years " },
                    { 19, null, 1, "Scientist" },
                    { 18, null, 1, "Product manager" },
                    { 17, null, 1, "Engineering manager " },
                    { 2, null, 1, "Developer, front-end" },
                    { 3, null, 1, "Developer, desktop or enterprise applications " },
                    { 4, null, 1, "Developer, mobile " },
                    { 5, null, 1, "DevOps specialist" },
                    { 6, null, 1, "Database administrator " },
                    { 7, null, 1, "Designer" },
                    { 8, null, 1, "System administrator " },
                    { 9, null, 1, "Developer, embedded applications or devices" },
                    { 10, null, 1, "Data or business analyst " },
                    { 11, null, 1, "Data scientist or machine learning specialist " },
                    { 12, null, 1, "Developer, QA or test " },
                    { 13, null, 1, "Engineer, data" },
                    { 14, null, 1, "Academic researcher " },
                    { 15, null, 1, "Educator " },
                    { 16, null, 1, "Developer, game or graphics " },
                    { 35, null, 3, "45 to 49 years " },
                    { 36, null, 3, "50 years or more" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OptionId",
                table: "Answers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_RespondId",
                table: "Answers",
                column: "RespondId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responds_SurveyId",
                table: "Responds",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responds_UserId",
                table: "Responds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserId",
                table: "Surveys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Responds");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
