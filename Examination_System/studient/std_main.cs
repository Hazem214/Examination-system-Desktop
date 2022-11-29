using Cproject;
using Examination_System.Ucontrols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Application = System.Windows.Forms.Application;

namespace Examination_System.studient
{
    public partial class std_main : Form
    {
        Context db = new Context();
        public string uNID { set; get; }
        public int s_id { set; get; }
        public std_main(string s)
        {
            uNID = s;
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void std_main_Load(object sender, EventArgs e)
        {
            full_namelbl.Text = getFullName();
            Instructor ins = new Instructor() { ID = 2, Email = "mail", Address = "xxx", NationalID = "2970811" };
            db.Instructors.Add(ins);
            db.SaveChanges();

            degress1.N_id = uNID;
            courses1.N_id = uNID;

            
            Timer timer1 = new Timer();
            timer1.Interval = (1000); // 45 mins
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timelbl.Text = DateTime.Now.ToString();
        }

        public string getFullName()
        {

            var x = db.Students.Where(s => s.NationalID == uNID)
                 .Select(s => new { s_id=s.ID,fname = s.FName, lname = s.LName }).FirstOrDefault();
            s_id = x.s_id;
            return x.fname + " " + x.lname;
        }

        private void course_Click(object sender, EventArgs e)
        {
            degress1.Visible = false;
            courses1.Visible = true;


        }

        private void degree_Click(object sender, EventArgs e)
        {
            degress1.Visible = true;
            courses1.Visible = false;

        }

       
        private void home_Click(object sender, EventArgs e)
        {
            degress1.Visible = false;
            courses1.Visible = false;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            ExamFrm exam1 = new ExamFrm();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dataGridView1.SelectedRows[0];
                exam1.Nid = uNID;
                exam1.Ex_id = int.Parse(r.Cells["ExamID"].Value.ToString());
                exam1.C_name = r.Cells["Course_Name"].Value.ToString();
                exam1.startD = DateTime.Parse(r.Cells["Startat"].Value.ToString());
                exam1.EndD = DateTime.Parse(r.Cells["EndAt"].Value.ToString());
                exam1.st_id = s_id;
                exam1.ShowDialog();
            }
            else
                MessageBox.Show("No Exams To Enter!!");
           
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            int s_id = db.Students.Where(s => s.NationalID == uNID).Select(s => s.ID).FirstOrDefault();
            var q = (from sc in db.StudentCourses
                     join c in db.Courses on sc.StudentID equals s_id
                     join ex in db.Exams on c.ID equals ex.CourseID
                  //   where ((ex.EndTime > DateTime.Now) && (ex.StartTime < DateTime.Now))
                     select (new { ExamID = ex.ID, Course_Name = c.Name, Startat = ex.StartTime, EndAt = ex.EndTime })).ToList();

            dataGridView1.DataSource = q;

            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.Columns.Count - 1;
            }

            dataGridView1.Width = 650;
        }

        private void degress1_Load(object sender, EventArgs e)
        {

        }
    }
}
