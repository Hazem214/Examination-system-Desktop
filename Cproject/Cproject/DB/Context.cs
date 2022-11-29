using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class Context : DbContext
    {
        public Context() : base("Data Source=.;Initial Catalog=ProjectExam;Integrated Security=True;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>().HasKey(p => new { p.StudentID, p.CourseID });
            modelBuilder.Entity<StudentAnswer>().HasKey(p => new { p.StudentID, p.QuestionID });
            modelBuilder.Entity<StudentExam>().HasKey(p => new { p.StudentID, p.ExamID });
            modelBuilder.Entity<InstructorStudent>().HasKey(p => new { p.StudentID, p.InstructorID });
            modelBuilder.Entity<Instructor>().HasOptional(i => i.Manager)
                                            .WithMany()
                                            .HasForeignKey(m => m.ManagerID);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }

        public virtual DbSet<StudentCourses> StudentCourses { get; set; }

        public virtual DbSet<InstructorStudent> InstructorStudents { get; set; }
        public virtual DbSet<QuestionExam> QuestionExams { get; set; }
        public virtual DbSet<QuestionChoice> QuestionChoices { get; set; }
        public virtual DbSet<QuestionTF> QuestionTFs { get; set; }

        public virtual DbSet<StudentExam> StudentExams { get; set; }
    }
}
