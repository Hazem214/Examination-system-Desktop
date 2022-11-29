using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public enum ExamType { Examination, Corrective}
    public class Exams
    {
        public int ID { get; set; }

        public ExamType ExamType { get; set; }

        public int Intake { get; set; }

        public string Track { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime TotalTime { get; set; }

        public string MoreOption { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }

        // navigation properties
        public virtual Courses Courses { get; set; }

        public virtual Instructor Instructors { get; set; }

        public virtual ICollection<QuestionExam> QuestionExams { get; set; }

        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}
