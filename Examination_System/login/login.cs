using Examination_System.studient;
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
using Cproject;
using Context = Cproject.Context;

namespace Examination_System
{
    public partial class login : Form
    {
        Context db = new Context();
        private string[] users = new string [] { "studient", "Instructor", "Manager" };
       
        public login()
        {
            InitializeComponent();
            comboBox2.Items.AddRange(users);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = comboBox2.SelectedItem.ToString();
            if (user == "studient")
            {
                if (is_student())
                {
                    std_main frm = new std_main(textBox2.Text);
                    frm.ShowDialog();
                    frm.uNID = textBox2.Text;
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong National ID!!!! ");
            }
            else if(user == "Instructor") {

                if (is_instructor())
                {
                    Form1 frm = new Form1();
                    frm.NationalID = textBox2.Text;
                    frm.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Wrong National ID!!!! ");
            }
        }
        private bool is_student()
        {
            //Context cont = new Context();
            Student st = db.Students.Where(s => s.NationalID == textBox2.Text)
                .Select(s=>s).FirstOrDefault();
            if (st == null)
                return false;

            return true;
        }
        private bool is_instructor()
        {
            Instructor instructor = db.Instructors.Where(ins => ins.NationalID == textBox2.Text)
                .Select(ins => ins).FirstOrDefault();
            if (instructor == null)
                return false;

            return true;
        }
        private bool is_manager(string N_id)
        {
           

            return true;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
