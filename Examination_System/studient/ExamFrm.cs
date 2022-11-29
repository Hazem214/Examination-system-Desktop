using Cproject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.studient
{
    
    public partial class ExamFrm : Form
    {
        Context db = new Context();
        public string Nid { set; get; }
        public int Ex_id { set; get; }
        public string C_name { set; get; }
        public DateTime startD { get; set; }
        public DateTime EndD { get; set; }
        public int st_id { set; get; }
        private int count { set; get; }
        private List<QuestionChoice> lqlist { set; get; }
        private List<answer> answerlist { set; get; }
        
        public ExamFrm()
        {
            InitializeComponent();
        }

        private void ExamFrm_Load(object sender, EventArgs e)
        {
            count = 0;
            lqlist = ex_Questions();
            answerlist = new List<answer>();
            foreach (var mcq in lqlist)
            {
                answerlist.Add(new answer() { q_id = mcq.ID, trueans = mcq.Answer, deg_q = 0, st_ans = "" });
            }
            if(lqlist.Count>0)
                showq(count);
            exidlbl.Text += Ex_id;
            cNamelbl.Text += C_name;
            qnumlbl.Text = "Q - " + (count + 1).ToString();

            Timer timer1 = new Timer();
            timer1.Interval = (1000); // 45 mins
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerlbl.Text = (EndD - DateTime.Now).Minutes.ToString() + ":" + (EndD - DateTime.Now).Seconds.ToString();
        }

        public List<QuestionChoice> ex_Questions()
        {
            return (from ex in db.Exams
                    join c in db.Courses on ex.CourseID equals c.ID
                    join mcq in db.QuestionChoices on c.ID equals mcq.CourseID
                    where ex.ID == Ex_id
                    select (mcq

                    )).ToList();

        }
        private void showq(int index)
        {
            qulbl.Text = lqlist[index].QuestionDes;
            ans.Text = lqlist[index].Option1;
            ans2.Text = lqlist[index].Option2;
            ans3.Text = lqlist[index].Option3;
            ans4.Text = lqlist[index].Option4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count < lqlist.Count-1)
            {
                string s = "";
                
                if (ans.Checked)
                    s = ans.Text;
                else if (ans2.Checked)
                    s = ans2.Text;
                else if (ans3.Checked)
                    s = ans3.Text;
                else if (ans4.Checked)
                    s = ans4.Text;
                answer ansobj = answerlist[count];
                ansobj.st_ans = s;
                answerlist[count] = ansobj;

                showq(++count);
                qnumlbl.Text = "Q - " + (count + 1).ToString();


            }

            else
                MessageBox.Show("No other Questions!!");
        }
        
        private void cNamelbl_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                showq(--count);
                qnumlbl.Text ="Q - " + (count + 1).ToString();
                string s = answerlist[count].st_ans;
                if (ans.Text==s)
                    ans.Checked=true;
                else if (ans2.Text==s)
                    ans.Checked = true;
                else if (ans3.Text==s)
                    ans.Checked = true;
                else if (ans4.Text==s)
                    ans.Checked = true;

            }

            else
                MessageBox.Show("this is the first Question!!");
        }

        private void sub_btn_Click(object sender, EventArgs e)
        {
            int deg = 0;
            panel2.Visible = false;
            qnumlbl.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            sub_btn.Visible = false;
            foreach(var item in answerlist)
            {
                if (item.trueans == item.st_ans)
                {
                    item.deg_q = 2;
                    deg += 2;
                }
            }
            label3.Text ="Q - "+ deg.ToString();
            if (deg >= (answerlist.Count * 2) / 2)
                label4.Text += "Passed";
            else
                label4.Text += "Failed";
            try
            {
                db.StudentExams.Add(new StudentExam() { ExamID = Ex_id, StudentID = st_id, Degree = deg });
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Unable to Enter Exam!");
            }
        }
    }
}
