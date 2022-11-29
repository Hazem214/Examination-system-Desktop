namespace Examination_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinDegree = c.Int(nullable: false),
                        MaxDegree = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamType = c.Int(nullable: false),
                        Intake = c.Int(nullable: false),
                        Track = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TotalTime = c.DateTime(nullable: false),
                        MoreOption = c.String(),
                        CourseID = c.Int(nullable: false),
                        Instructors_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructors_ID)
                .Index(t => t.CourseID)
                .Index(t => t.Instructors_ID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(maxLength: 20),
                        LName = c.String(maxLength: 20),
                        Phone = c.String(maxLength: 11),
                        Email = c.String(maxLength: 20),
                        Address = c.String(maxLength: 50),
                        NationalID = c.String(nullable: false, maxLength: 10),
                        ManagerID = c.Int(),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Instructors", t => t.ManagerID)
                .Index(t => t.ManagerID);
            
            CreateTable(
                "dbo.QuestionExams",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionDes = c.String(),
                        Answer = c.String(),
                        Degree = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Exams_ID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exams_ID)
                .Index(t => t.CourseID)
                .Index(t => t.Exams_ID);
            
            CreateTable(
                "dbo.StudentAnswers",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Student_answer = c.String(),
                    })
                .PrimaryKey(t => new { t.StudentID, t.QuestionID })
                .ForeignKey("dbo.QuestionExams", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(maxLength: 20),
                        LName = c.String(maxLength: 20),
                        Phone = c.String(maxLength: 11),
                        Email = c.String(maxLength: 20),
                        Address = c.String(maxLength: 50),
                        NationalID = c.String(nullable: false, maxLength: 10),
                        Intake = c.Int(nullable: false),
                        Track = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Degree = c.Int(),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        ExamID = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.ExamID })
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionDes = c.String(),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        Option3 = c.String(),
                        Option4 = c.String(),
                        Answer = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.InstructorStudents",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.InstructorID })
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.QuestionTFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionDes = c.String(),
                        Option1 = c.String(nullable: false),
                        Option2 = c.String(nullable: false),
                        answer = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionTFs", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.InstructorStudents", "StudentID", "dbo.Students");
            DropForeignKey("dbo.InstructorStudents", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.QuestionChoices", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.StudentAnswers", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentExams", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentExams", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentAnswers", "QuestionID", "dbo.QuestionExams");
            DropForeignKey("dbo.QuestionExams", "Exams_ID", "dbo.Exams");
            DropForeignKey("dbo.QuestionExams", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Instructors", "ManagerID", "dbo.Instructors");
            DropForeignKey("dbo.Exams", "Instructors_ID", "dbo.Instructors");
            DropForeignKey("dbo.Exams", "CourseID", "dbo.Courses");
            DropIndex("dbo.QuestionTFs", new[] { "CourseID" });
            DropIndex("dbo.InstructorStudents", new[] { "InstructorID" });
            DropIndex("dbo.InstructorStudents", new[] { "StudentID" });
            DropIndex("dbo.QuestionChoices", new[] { "CourseID" });
            DropIndex("dbo.StudentExams", new[] { "ExamID" });
            DropIndex("dbo.StudentExams", new[] { "StudentID" });
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            DropIndex("dbo.StudentAnswers", new[] { "QuestionID" });
            DropIndex("dbo.StudentAnswers", new[] { "StudentID" });
            DropIndex("dbo.QuestionExams", new[] { "Exams_ID" });
            DropIndex("dbo.QuestionExams", new[] { "CourseID" });
            DropIndex("dbo.Instructors", new[] { "ManagerID" });
            DropIndex("dbo.Exams", new[] { "Instructors_ID" });
            DropIndex("dbo.Exams", new[] { "CourseID" });
            DropIndex("dbo.Courses", new[] { "InstructorID" });
            DropTable("dbo.QuestionTFs");
            DropTable("dbo.InstructorStudents");
            DropTable("dbo.QuestionChoices");
            DropTable("dbo.StudentExams");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentAnswers");
            DropTable("dbo.QuestionExams");
            DropTable("dbo.Instructors");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
