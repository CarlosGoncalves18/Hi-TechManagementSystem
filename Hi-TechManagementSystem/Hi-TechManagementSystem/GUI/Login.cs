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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if ((textBoxUserName.Text == "") || (textBoxPassword.Text == ""))
            {
                MessageBox.Show("You must fill out all of the boxes, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Users user = UserDA.Search(textBoxUserName.Text);
                string textUser = textBoxUserName.Text;
                string textPass = textBoxPassword.Text;

                if (user == null)
                {
                    MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxUserName.Clear();
                    textBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
                else
                {
                    if (user.Password == textBoxPassword.Text)
                    {
                        if (user.UserJobTitle == "Manager")
                        {
                            this.Hide();
                            MIS_Management form2 = new MIS_Management();
                            form2.Show();
                        }
                        else if (user.UserJobTitle == "Sales Manager")
                        {
                            this.Hide();
                            Sales_Manager form3 = new Sales_Manager();
                            form3.Show();
                        }
                        else if (user.UserJobTitle == "Inventory Controller")
                        {
                            this.Hide();
                            Inventory_Control form4 = new Inventory_Control();
                            form4.Show();
                        }
                        else if (user.UserJobTitle == "Order Clerks")
                        {
                            this.Hide();
                            Orders_Clerk form5 = new Orders_Clerk();
                            form5.Show();
                        }
                    }
                    else if (user.Password != textBoxPassword.Text)
                    {
                        MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                        return;
                    }
                    else if (user.UserName != textBoxUserName.Text)
                    {
                        MessageBox.Show("Wrong Information, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                        return;
                    }
                }
            }
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AboutBox_Hi_TechManagementSystem form6 = new AboutBox_Hi_TechManagementSystem();
            form6.Show();
        }
        private void buttonPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword_Form form7 = new ForgotPassword_Form();
            form7.Show();
        }
    }
}
