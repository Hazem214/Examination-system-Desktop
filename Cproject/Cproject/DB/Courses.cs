using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class Courses
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int MinDegree { get; set; }

        public int MaxDegree { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        // navigation properties
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<Exams> Exams { get; set; }

        public virtual ICollection<QuestionExam> QuestionExams { get; set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
