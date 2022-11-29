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
    public partial class AddStudent : UserControl
    {
        Context db = new Context();
        Student student= new Student();
        public int id;
        public AddStudent()
        {
            InitializeComponent();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                student.ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                id = student.ID;
                student = db.Students.Where(i => i.ID == student.ID).FirstOrDefault();

                textFName.Text = student.FName;
                textLname.Text = student.LName;
                textPhone.Text = student.Phone;
                textEmail.Text = student.Email;
                textAddress.Text = student.Address;
                textNationalid.Text = student.NationalID;
                textintake.Text = student.Intake.ToString();
                textTrack.Text = student.Track;


            }

        }
        void clear()
        {
            textAddress.Text = textFName.Text = textLname.Text = textEmail.Text = textintake.Text = textPhone.Text=textNationalid.Text=textTrack.Text = "";

        }

        void showData()
        {



            dataGridView2.DataSource = db.Students.ToList<Student>();

           


        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

            clear();
            showData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            student.FName = textFName.Text;
            student.LName = textLname.Text;
            student.Phone= textPhone.Text;
            student.Email= textEmail.Text;
            student.Address= textAddress.Text;
            student.NationalID = textNationalid.Text;
            student.Track = textTrack.Text;
            student.Intake =Convert.ToInt32(textintake.Text);
            db.Students.Add(student);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("add successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            student.ID = id;
            student = db.Students.Where(x => x.ID == student.ID).FirstOrDefault();
            student.FName = textFName.Text;
            student.LName = textLname.Text;
            student.Phone = textPhone.Text;
            student.Email = textEmail.Text;
            student.Address = textAddress.Text;
            student.NationalID = textNationalid.Text;
            student.Track = textTrack.Text;
            student.Intake = Convert.ToInt32(textintake.Text);

            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Update successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            student.ID = id;
            student = db.Students.Where(x => x.ID == student.ID).FirstOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();

            clear();
            showData();
            MessageBox.Show("Delete successfully");
        }
    }
}
