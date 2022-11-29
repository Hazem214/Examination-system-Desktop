using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cproject
{
    public partial class AssignStudent : UserControl
    {
        Context db = new Context();
        StudentCourses courseStudent = new StudentCourses();
        public int id;
        public int id2;
        public AssignStudent()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            courseStudent.CourseID = int.Parse(textCourse.Text);
            courseStudent.StudentID = int.Parse(textStudent.Text);

            db.StudentCourses.Add(courseStudent);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("add successfully");
        }

        

        void clear()
        {
            textCourse.Text = textStudent.Text = "";
        }

        void showData()
        {
            dataGridView2.AutoGenerateColumns = false;

            dataGridView2.DataSource = db.StudentCourses.ToList<StudentCourses>();


        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                courseStudent.CourseID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["CourseID"].Value);
                id = courseStudent.CourseID;
                courseStudent.StudentID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["StudentID"].Value);
                id2 = courseStudent.StudentID;
                courseStudent = db.StudentCourses.Where(i => (i.CourseID == id) && (i.StudentID == id2)).FirstOrDefault();
                
                textCourse.Text = courseStudent.CourseID.ToString();
                textStudent.Text = courseStudent.StudentID.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            courseStudent.CourseID = id;
            courseStudent.StudentID = id2;
            courseStudent = db.StudentCourses.Where(x => (x.CourseID == courseStudent.CourseID) && (x.StudentID == courseStudent.StudentID)).FirstOrDefault();

            courseStudent.CourseID = int.Parse(textCourse.Text);
            courseStudent.CourseID = int.Parse(textStudent.Text);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Update successfully");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            courseStudent.CourseID = id;
            courseStudent.StudentID = id2;
            courseStudent = db.StudentCourses.Where(x => (x.CourseID == courseStudent.CourseID) && (x.StudentID == courseStudent.StudentID)).FirstOrDefault();
            db.StudentCourses.Remove(courseStudent);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Delete successfully");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AssignStudent_Load(object sender, EventArgs e)
        {
            clear();
            showData();
        }
    }
}
