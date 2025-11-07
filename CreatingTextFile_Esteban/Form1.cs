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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmFileName FileNameForm = new FrmFileName();
            string getInput = txtInput.Text;
            FileNameForm.ShowDialog();
            string relativePath = @"..\..\FileStorage";
            string docPath = Path.GetFullPath(relativePath);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                outputFile.WriteLine(getInput);
                Console.WriteLine(getInput);
            }

            DialogResult result = MessageBox.Show("File created successfully!", "Success", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                FrmRegistration registrationForm = new FrmRegistration();
                registrationForm.Show();
                this.Hide();
            }
        }
    }
}
