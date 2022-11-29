using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public enum Option { True, False}
    public class QuestionTF
    {
        public int ID { get; set; }

        public string QuestionDes { get; set; }

        [Required]
        public string Option1 { get; set; }

        [Required]
        public string Option2 { get; set; }

        public string answer { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }

        // navigation property

        public virtual Courses Courses { get; set; }
    }
}
