using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class QuestionExam
    {
        [Key]
        public int QuestionID { get; set; }

        public string QuestionDes { get; set; }

        public string Answer { get; set; }

        public int Degree { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }

      


        // navigation property
        public virtual Courses Courses { get; set; }
        
        public virtual Exams Exams { get; set; }   
        
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
