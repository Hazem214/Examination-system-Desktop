using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class QuestionChoice
    {
        public int ID { get; set; }

        public string QuestionDes { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        public string Answer { get; set; }

        [ForeignKey("Courses")]
        public int CourseID { get; set; }

        // navigation property

        public virtual Courses Courses { get; set; }
    }
}
