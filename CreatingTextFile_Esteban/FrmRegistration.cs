using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile_Esteban
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentNumber = txtStudentNo.Text.Trim();
            if (string.IsNullOrEmpty(studentNumber))
            {
                MessageBox.Show("Please enter a student number.");
                return;
            }

            string[] studentInfo = {
                "Student Number: " + studentNumber,
                "Last Name: " + txtLastName.Text,
                "First Name: " + txtFirstName.Text,
                "Middle Name: " + txtMiddleName.Text,
                "Gender: " + cbGender.Text,
                "Birthday: " + dateTimeBirthday.Value.ToShortDateString(),
                "Program: " + cbProgram.Text,
                "Contact No: " + txtContactNo.Text,
                "Age: " + txtAge.Text
            };

            string relativePath = @"..\..\FileStorage";
            string docPath = Path.GetFullPath(relativePath);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, studentNumber + ".txt")))
            {
                foreach (string info in studentInfo)
                {
                    outputFile.WriteLine(info);
                }
            }
            MessageBox.Show("Registration file created!");
            Application.Exit();
        }
    }
}
