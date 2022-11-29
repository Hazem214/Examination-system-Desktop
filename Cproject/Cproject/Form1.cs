using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cproject
{
    public partial class Form1 : Form
    {
        public string NationalID { get; set; }
        public Form1()
        {
            InitializeComponent();

            if(NationalID == "123456")
            {
                button6.Visible = true;
            }

            #region add instructor
            //Context db = new Context();
            //Instructor instructor = new Instructor() { FName = "ahmed", LName = "mohamed", Phone = "012431443", Email = "hazem@gmail.com", Address = "beba", NationalID = "afda", BranchName = "menia", ManagerID = 1 };
            //db.Instructors.Add(instructor);
            //db.SaveChanges(); 
            #endregion


        }

        private void button3_Click(object sender, EventArgs e)
        {
            exam1.Visible = true;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible= true;
            addStudent1.Visible= false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = true;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = true;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = true;
            assignStudent1.Visible = false;
            addInstructor1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = true;
            addInstructor1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (NationalID == "123456")
            {
                button6.Visible = true;
                button7.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exam1.Visible = false;
            questionForm1.Visible = false;
            addStudent1.Visible = false;
            createNewExam1.Visible = false;
            degreeofstudent1.Visible = false;
            assignStudent1.Visible = false;
            addInstructor1.Visible = true;
        }
    }
}
