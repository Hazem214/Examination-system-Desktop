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

namespace Cproject
{
    public partial class QuestionForm : UserControl
    {

        Context db = new Context();
        QuestionChoice question = new QuestionChoice();
        public int id;
        public QuestionForm()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            question.QuestionDes = textQuestion.Text;
            question.Option1 = textOption1.Text;
            question.Option2 = textOption2.Text;
            question.Option3 = textOption3.Text;
            question.Option4 = textOption4.Text;
            question.Answer = textAnswer.Text;
            question.CourseID = int.Parse(textCourse.Text);
            db.QuestionChoices.Add(question);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("add successfully");
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            clear();
            showData();
        }

        void clear()
        {
            textAnswer.Text = textCourse.Text = textOption1.Text = textOption2.Text = textQuestion.Text = textOption3.Text = textOption4.Text = "";
        }

        void showData()
        {
            // dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = db.QuestionTFs.ToList<QuestionTF>();
            dataGridView2.DataSource = db.QuestionChoices.ToList<QuestionChoice>();


        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                question.ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                id = question.ID;
                question = db.QuestionChoices.Where(i => i.ID == question.ID).FirstOrDefault();
                textQuestion.Text = question.QuestionDes;
                textOption1.Text = question.Option1;
                textOption2.Text = question.Option2;
                textOption3.Text = question.Option3;
                textOption4.Text = question.Option4;
                textAnswer.Text = question.Answer;
                textCourse.Text = question.CourseID.ToString();


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            question.ID = id;
            question = db.QuestionChoices.Where(x => x.ID == question.ID).FirstOrDefault();

            question.QuestionDes = textQuestion.Text;
            question.Option1 = textOption1.Text;
            question.Option2 = textOption2.Text;
            question.Option3 = textOption3.Text;
            question.Option4 = textOption4.Text;
            question.Answer = textAnswer.Text;
            question.CourseID = int.Parse(textCourse.Text);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Update successfully");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            question.ID = id;
            question = db.QuestionChoices.Where(x => x.ID == question.ID).FirstOrDefault();
            db.QuestionChoices.Remove(question);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Delete successfully");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView2.Visible = true;
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }
    }
}
