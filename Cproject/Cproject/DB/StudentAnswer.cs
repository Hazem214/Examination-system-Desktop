using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class StudentAnswer
    {
        [ForeignKey("QuestionExam")]
        public int QuestionID { get; set; }
        public virtual QuestionExam QuestionExam { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public string Student_answer { get; set; }
    }
}
