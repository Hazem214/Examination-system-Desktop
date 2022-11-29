using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class Student
    {
        public int ID { get; set; }

        [MaxLength(20)]
        public string FName { get; set; }

        [MaxLength(20)]
        public string LName { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [Required, MaxLength(10)]
        public string NationalID { get; set; }

        public int Intake { get; set; }

        [MaxLength(50)]
        public string Track { get; set; }

        // navigation properties
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

        public virtual ICollection<StudentExam> StudentExams { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
