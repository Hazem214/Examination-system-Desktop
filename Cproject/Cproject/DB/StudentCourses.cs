using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class StudentCourses
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }
        public virtual Courses Courses { get; set; }

        public int? Degree { get; set; }
    }
}
