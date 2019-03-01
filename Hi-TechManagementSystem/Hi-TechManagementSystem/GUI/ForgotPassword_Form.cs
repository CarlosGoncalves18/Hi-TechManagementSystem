using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_TechDistributionClassLibrary.Business;
using Hi_TechDistributionClassLibrary.DataAccess;


namespace Hi_TechManagementSystem.GUI
{
    public partial class ForgotPassword_Form : Form
    {
        public ForgotPassword_Form()
        {
            InitializeComponent();
        }

        List<Users> listU = new List<Users>();

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("You must fill out all of the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Users user = UserDA.Search(textBoxUserName.Text);
                string textUser = textBoxUserName.Text;

                if (user == null)
                {
                    MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxUserName.Clear();
                    textBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
                else
                {
                    user.Password = textBoxPassword.Text;
                    UserDA.Update(user);
                    MessageBox.Show("User Password has been updated successfully", "Confirmation");
                }
                this.Hide();
                Login form = new Login();
                form.Show();
            }
        }
        private void buttonReturn_Click(object sender, EventArgs e)
            {
                this.Hide();
                Login form = new Login();
                form.Show();
            }
    }
}