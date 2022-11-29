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
    public partial class AddInstructor : UserControl
    {
        Context db = new Context();
        Instructor instructor = new Instructor();
        public int id;
        public AddInstructor()
        {
            InitializeComponent();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                instructor.ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                id = instructor.ID;
                instructor = db.Instructors.Where(i => i.ID == instructor.ID).FirstOrDefault();

                textFName.Text = instructor.FName;
                textLname.Text = instructor.LName;
                textPhone.Text = instructor.Phone;
                textEmail.Text = instructor.Email;
                textAddress.Text = instructor.Address;
                textNationalid.Text = instructor.NationalID;
                textManagerID.Text = instructor.ManagerID.ToString();
                textBranch.Text = instructor.BranchName;


            }

        }
        void clear()
        {
            textAddress.Text = textFName.Text = textLname.Text = textEmail.Text = textManagerID.Text = textPhone.Text = textNationalid.Text = textBranch.Text = "";

        }

        void showData()
        {



            dataGridView2.DataSource = db.Instructors.ToList<Instructor>();




        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            instructor.FName = textFName.Text;
            instructor.LName = textLname.Text;
            instructor.Phone = textPhone.Text;
            instructor.Email = textEmail.Text;
            instructor.Address = textAddress.Text;
            instructor.NationalID = textNationalid.Text;
            instructor.ManagerID = int.Parse(textManagerID.Text);
            instructor.BranchName = textBranch.Text;
            db.Instructors.Add(instructor);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("add successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            instructor.ID = id;
            instructor = db.Instructors.Where(x => x.ID == instructor.ID).FirstOrDefault();
            instructor.FName = textFName.Text;
            instructor.LName = textLname.Text;
            instructor.Phone = textPhone.Text;
            instructor.Email = textEmail.Text;
            instructor.Address = textAddress.Text;
            instructor.NationalID = textNationalid.Text;
            instructor.ManagerID = int.Parse(textManagerID.Text);
            instructor.BranchName = textBranch.Text;

            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Update successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            instructor.ID = id;
            instructor = db.Instructors.Where(x => x.ID == instructor.ID).FirstOrDefault();
            db.Instructors.Remove(instructor);
            db.SaveChanges();

           clear();
            showData(); 
            MessageBox.Show("Delete successfully");
        }

        private void AddInstructor_Load(object sender, EventArgs e)
        {
            clear();
            showData();
        }
    }
}
