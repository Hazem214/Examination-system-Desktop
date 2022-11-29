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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cproject
{
    public partial class Exam : UserControl
    {
        Context db = new Context();
        QuestionTF question = new QuestionTF();
        QuestionExam QuestionExam1= new QuestionExam();
        QuestionChoice Choice = new QuestionChoice();
        public int id;
        public int courseidcheck;
        public Exam()
        {
            InitializeComponent();
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            clear();
            showData();
        }
        void clear()
        {
            textQestion.Text = textAnswer.Text = textDegree.Text = textCourseId.Text = textExamID.Text = "";
            
        }

        void showData()
        {
            dataGridView1.AutoGenerateColumns = false;
            

            dataGridView1.DataSource = db.QuestionTFs.ToList<QuestionTF>();

            dataGridView2.DataSource = db.QuestionExams.ToList<QuestionExam>();

            dataGridView3.DataSource = db.QuestionChoices.ToList<QuestionChoice>();


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                question.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                id = question.ID;
              
                question = db.QuestionTFs.Where(i => i.ID == question.ID).FirstOrDefault();

                textQestion.Text = question.QuestionDes;
                textAnswer.Text = question.answer;



            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            courseidcheck = Convert.ToInt32(textCourseId.Text);
            var checking=  db.QuestionExams.Where(i=>i.CourseID==courseidcheck).Select(i => i.Degree).ToList();
            int degree=0;
            foreach(var deg in checking)
            {
                degree +=Convert.ToInt32(deg);
            }
            if (degree >= 100) {
                MessageBox.Show("max degree of this couse is 100 ");
            }
            else { 

            QuestionExam1.QuestionDes = textQestion.Text;
            QuestionExam1.Answer = textAnswer.Text;
            QuestionExam1.Degree =Convert.ToInt32( textDegree.Text);
            QuestionExam1.CourseID = Convert.ToInt32( textCourseId.Text);
            int examId=Convert.ToInt32( textExamID.Text);
            var exam= db.Exams.Where(i => i.ID == examId).FirstOrDefault();
            QuestionExam1.Exams = exam;

            db.QuestionExams.Add(QuestionExam1);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("add successfully");
            }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Choice.ID = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                id = Choice.ID;
                Choice = db.QuestionChoices.Where(i => i.ID == Choice.ID).FirstOrDefault();

                textQestion.Text = Choice.QuestionDes;
                textAnswer.Text = Choice.Answer;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
            }
            else
            {
                dataGridView3.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            QuestionExam1.QuestionID = id;
            QuestionExam1 = db.QuestionExams.Where(x => x.QuestionID == QuestionExam1.QuestionID).FirstOrDefault();
            db.QuestionExams.Remove(QuestionExam1);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Delete successfully");
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                QuestionExam1.QuestionID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                id = QuestionExam1.QuestionID;
                QuestionExam1 = db.QuestionExams.Where(i => i.QuestionID == QuestionExam1.QuestionID).FirstOrDefault();

                textQestion.Text = QuestionExam1.QuestionDes;
                textAnswer.Text = QuestionExam1.Answer;


            }
        }
    }
}
