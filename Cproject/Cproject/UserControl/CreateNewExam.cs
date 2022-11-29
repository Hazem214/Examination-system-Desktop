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
    public partial class CreateNewExam : UserControl
    {
        Context db = new Context();
        Exams exam = new Exams();
        public int id;
        public CreateNewExam()
        {
            InitializeComponent();
        }

        private void CreateNewExam_Load(object sender, EventArgs e)
        {
            clear();
            showData();
        }
        void clear()
        {
            textExamtype.Text = textintakeexam.Text = textTrack.Text = textStartTime.Text = textEndtime.Text = textTotalTime.Text = textMoreOption.Text = textCourseId.Text = textINstructiorId.Text = "";

        }

        void showData()
        {



            dataGridView2.DataSource = db.Exams.ToList<Exams>();




        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                exam.ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                id = exam.ID;
                exam = db.Exams.Where(i => i.ID == exam.ID).FirstOrDefault();

                textExamtype.Text=exam.Intake.ToString();
                textintakeexam.Text=exam.Intake.ToString();
                textTrack.Text = exam.Track;
                textStartTime.Text = exam.StartTime.ToString();
                textEndtime.Text = exam.EndTime.ToString();
                textTotalTime.Text = exam.TotalTime.ToString();
                textMoreOption.Text = exam.MoreOption;
                textCourseId.Text=exam.CourseID.ToString();
                int pid=exam.ID;
                int insID = db.Instructors.Where(i => i.ID == pid).Select(i => i.ID).FirstOrDefault();
                textINstructiorId.Text = insID.ToString();


            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //  exam.
            if (textExamtype.Text == "corrective") exam.ExamType = ExamType.Corrective;
            else exam.ExamType = ExamType.Examination;
            exam.Intake =int.Parse( textintakeexam.Text);
            exam.Track = textTrack.Text;
            exam.StartTime =Convert.ToDateTime( textStartTime.Text);
            exam.EndTime= Convert.ToDateTime(textEndtime.Text);
            exam.TotalTime= Convert.ToDateTime(textTotalTime.Text);
            exam.MoreOption = textMoreOption.Text;
            exam.CourseID = Convert.ToInt32(textCourseId.Text);
            int pid =Convert.ToInt32(textINstructiorId.Text);
            var instrctuor = db.Instructors.Where(i => i.ID == pid).FirstOrDefault();
            exam.Instructors = instrctuor;
            
            db.Exams.Add(exam);
            db.SaveChanges();
            clear();
            showData();
            MessageBox.Show("add successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            exam.ID = id;
            exam = db.Exams.Where(i => i.ID == exam.ID).FirstOrDefault();
            if (textExamtype.Text == "corrective") exam.ExamType = ExamType.Corrective;
            else exam.ExamType = ExamType.Examination;
            exam.Intake = int.Parse(textintakeexam.Text);
            exam.Track = textTrack.Text;
            exam.StartTime = Convert.ToDateTime(textStartTime.Text);
            exam.EndTime = Convert.ToDateTime(textEndtime.Text);
            exam.TotalTime = Convert.ToDateTime(textTotalTime.Text);
            exam.MoreOption = textMoreOption.Text;
            exam.CourseID = Convert.ToInt32(textCourseId.Text);
            int pid = Convert.ToInt32(textINstructiorId.Text);
            var instrctuor = db.Instructors.Where(i => i.ID == pid).FirstOrDefault();
            exam.Instructors = instrctuor;

            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Update successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            exam.ID = id;
            exam = db.Exams.Where(i => i.ID == exam.ID).FirstOrDefault();
            db.Exams.Remove(exam);
            db.SaveChanges();
            clear();
            showData();
            MessageBox.Show("Delete Successfully");
        }
    }
}
