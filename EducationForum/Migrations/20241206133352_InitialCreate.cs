using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationForum.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Template");

            migrationBuilder.EnsureSchema(
                name: "EForumMaster");

            migrationBuilder.EnsureSchema(
                name: "EForum");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Template",
                columns: table => new
                {
                    CourseTemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseHeading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectID = table.Column<short>(type: "smallint", nullable: false),
                    GradeFrom = table.Column<short>(type: "smallint", nullable: false),
                    GradeTo = table.Column<short>(type: "smallint", nullable: false),
                    IsGroupClassAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MaxStudentForGroupClass = table.Column<short>(type: "smallint", nullable: true),
                    IsIndividualClassAvailable = table.Column<bool>(type: "bit", nullable: false),
                    InstructorID = table.Column<short>(type: "smallint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(1)"),
                    DeactivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseTemplateID);
                });

            migrationBuilder.CreateTable(
                name: "EForumMaster.Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EForumMaster.Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "EForumMaster",
                columns: table => new
                {
                    GenderID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "EForumMaster",
                columns: table => new
                {
                    StateID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "EForum",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    UserType = table.Column<short>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<short>(type: "smallint", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "(1)"),
                    DeactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<int>(type: "int", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "(0)"),
                    LockedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "(0)"),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginAttemptCount = table.Column<int>(type: "int", nullable: true),
                    IsTwoFactorAuthentication = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "EForumMaster",
                columns: table => new
                {
                    UserTypeID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Template");

            migrationBuilder.DropTable(
                name: "EForumMaster.Subjects");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "EForumMaster");

            migrationBuilder.DropTable(
                name: "State",
                schema: "EForumMaster");

            migrationBuilder.DropTable(
                name: "User",
                schema: "EForum");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "EForumMaster");
        }
    }
}
