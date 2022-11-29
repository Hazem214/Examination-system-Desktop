using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class InstructorStudent
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
