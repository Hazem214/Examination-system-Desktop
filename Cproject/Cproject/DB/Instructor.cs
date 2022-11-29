using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject
{
    public class Instructor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [MaxLength(10), Required]
        public string NationalID { get; set; }


        public int? ManagerID { get; set; }
        public string BranchName { get; set; }

        // navigation properties

        public virtual Instructor Manager { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }   

        public virtual ICollection<Exams> Exams { get; set; }
    }
}
