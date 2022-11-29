using Cproject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.Ucontrols
{
    public partial class Degress : UserControl
    {
        Context db = new Context();
        public string N_id { set; get; }
        public Degress()
        {
            
            InitializeComponent();
        }

        private void Degress_Load(object sender, EventArgs e)
        {
            
        }
        public void viewDegrees()
        {
            int s_id = db.Students.Where(s => s.NationalID == N_id).Select(s => s.ID).FirstOrDefault();
            var q = from s in db.Students
                    join se in db.StudentExams on s.ID equals se.StudentID
                    join e in db.Exams on se.ExamID equals e.ID
                    join c in db.Courses on e.CourseID equals c.ID
                    where (s.ID == s_id)
                    select (new { id=e.ID,cname=c.Name ,tname= e.Track, deg=se.Degree });

            dataGridView1.Rows.Clear();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ColumnCount = 4;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Columns[0].Name = "Exam ID";
            dataGridView1.Columns[1].Name = "Course Name";
            dataGridView1.Columns[2].Name = "Track name";
            dataGridView1.Columns[3].Name = "Exam Degree";
            dataGridView1.Columns[0].Width = dataGridView1.Width * 20 / 100;
            dataGridView1.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView1.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView1.Columns[3].Width = dataGridView1.Width * 20 / 100;
            foreach (var item in q)
            {
                dataGridView1.Rows.Add(item.id,item.cname,item.tname,item.deg);
            }
            dataGridView1.Height = (dataGridView1.RowCount * 18) + 35;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewDegrees();
        }
    }
}
