using Cproject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System
{
    public partial class courses : UserControl
    {

        public string N_id { set; get; }
        Context db = new Context();
        public courses()
        {

            InitializeComponent();
        }

        private void courses_Load(object sender, EventArgs e)
        {

        }

        public void viewCorses()
        {

            int s_id = db.Students.Where(s => s.NationalID == N_id).Select(s => s.ID).FirstOrDefault();
            var q = from s in db.Students
                    join sc in db.StudentCourses on s.ID equals sc.StudentID
                    join c in db.Courses on sc.CourseID equals c.ID
                    where (s.ID == s_id)
                    select (new { c.ID, c.Name, c.MaxDegree, c.MinDegree });

            dataGridView1.Rows.Clear();
            if (q != null)
            {

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ColumnCount = 4;
                dataGridView1.ScrollBars = ScrollBars.Vertical;
                dataGridView1.Columns[0].Name = "Course ID";
                dataGridView1.Columns[1].Name = "Course Name";
                dataGridView1.Columns[2].Name = "Max Degree";
                dataGridView1.Columns[3].Name = "Min Degree";
                dataGridView1.Columns[0].Width = dataGridView1.Width * 20 / 100;
                dataGridView1.Columns[1].Width = dataGridView1.Width * 35 / 100;
                dataGridView1.Columns[2].Width = dataGridView1.Width * 25 / 100;
                dataGridView1.Columns[3].Width = dataGridView1.Width * 20 / 100;
                foreach (var item in q)
                {
                    dataGridView1.Rows.Add(item.ID, item.Name, item.MaxDegree, item.MinDegree);
                }
                dataGridView1.Height = (dataGridView1.RowCount * 18) + 35;
            }
            else
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ColumnCount = 4;
                dataGridView1.ScrollBars = ScrollBars.Vertical;
                dataGridView1.Columns[0].Name = "Course ID";
                dataGridView1.Columns[1].Name = "Course Name";
                dataGridView1.Columns[2].Name = "Max Degree";
                dataGridView1.Columns[3].Name = "Min Degree";
                dataGridView1.Columns[0].Width = dataGridView1.Width * 20 / 100;
                dataGridView1.Columns[1].Width = dataGridView1.Width * 35 / 100;
                dataGridView1.Columns[2].Width = dataGridView1.Width * 25 / 100;
                dataGridView1.Columns[3].Width = dataGridView1.Width * 20 / 100;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            viewCorses();

        }
    }
}
