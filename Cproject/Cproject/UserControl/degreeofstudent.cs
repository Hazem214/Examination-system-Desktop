using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cproject
{
    public partial class degreeofstudent : UserControl
    {
        Context db = new Context();
        public degreeofstudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            var nameOfStudetn = textBox1.Text;
            int idstudent = db.Students.Where(i => i.FName == nameOfStudetn).Select(i=>i.ID).ToList().FirstOrDefault();
            string firstname = db.Students.Where(i => i.ID == idstudent).Select(i => i.FName).ToList().FirstOrDefault();
            string lastname = db.Students.Where(i => i.ID == idstudent).Select(i => i.LName).ToList().FirstOrDefault();
            string name = firstname +" "+ lastname;
            int degree = db.StudentExams.Where(i => i.StudentID == idstudent).Select(i=>i.Degree).ToList().FirstOrDefault();
            int examId = db.StudentExams.Where(i => i.StudentID == idstudent).Select(i => i.ExamID).ToList().FirstOrDefault();
            ExamType examName = db.Exams.Where(i => i.ID == examId).Select(i => i.ExamType).ToList().FirstOrDefault();
            if (idstudent != 0)
            {
                lableName.Visible= true;
                lableDegree.Visible = true;
                label3.Visible = true;
                lableName.Text = name;
                lableDegree.Text = degree.ToString();
                label3.Text = examName.ToString();
                
            }
            else
            {
                MessageBox.Show("Student Not Fountd ");
            }
            idstudent = 0;
        }
        public void clear()
        {
            lableDegree.Text = "";
            lableName.Text = "";
        }
    }
}
