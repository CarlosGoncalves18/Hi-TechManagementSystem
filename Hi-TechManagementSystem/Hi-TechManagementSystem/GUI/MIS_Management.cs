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
using Hi_TechDistributionClassLibrary.Validation;

namespace Hi_TechManagementSystem.GUI
{
    public partial class MIS_Management : Form
    {
        public MIS_Management()
        {
            InitializeComponent();
            EmployeeDA.ListEmployee(listViewEmployee);
            EmployeeDA.ListEmployee(listViewEmployee2);
            UserDA.ListUser(listViewUsers);
        }

        List<Employees> listEmp = new List<Employees>();
        List<Users> listU = new List<Users>();

        private bool IsValidEmployeeData()
        {
            return

               Validation.IsInteger(textBoxEmployeeId)
               && Validation.IsRightNumber(textBoxEmployeeId)
               && Validation.IsPresent(textBoxEmployeeId) && Validation.IsPresent(textBoxFirstName) && Validation.IsPresent(textBoxLastName)
               && Validation.IsPresent(textBoxEmail) && Validation.IsPresentComboBox(comboBoxJobTitle) && Validation.IsPresentComboBox(comboBoxStatus)
               && Validation.IsString(textBoxFirstName) && Validation.IsString(textBoxLastName);
        }
        private void buttonExitEmployee_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to logout the application?", "Confirmation",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            panelEmployee.Hide();
            panelUser.Show();
        }
        private void buttonCreateEmployee_Click_1(object sender, EventArgs e)
        {
            panelUser.Hide();
            panelEmployee.Show();
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form2 = new Login();
            form2.Show();
        }
        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            List<Employees> listEmp = EmployeeDA.ListEmployee();

            if (IsValidEmployeeData())
            {
                if (!Validation.IsUniqueEmployeeID(listEmp, Convert.ToInt32(textBoxEmployeeId.Text)))
                {
                    MessageBox.Show(" DUPLICATE ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxEmployeeId.Clear();
                    textBoxEmployeeId.Focus();
                    return;
                }
                else
                {
                    Employees Employees = new Employees();
                    Employees.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
                    Employees.FirstName = textBoxFirstName.Text;
                    Employees.LastName = textBoxLastName.Text;
                    Employees.JobTitle = comboBoxJobTitle.Text;
                    Employees.HomePhone = maskedTextBoxPhone.Text;
                    Employees.Email = textBoxEmail.Text;
                    Employees.Status = comboBoxStatus.Text;
                    EmployeeDA.Save(Employees);
                    listEmp.Add(Employees);
                    buttonListEmployee.Enabled = true;
                    ClearAll();
                }
            }
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            List<Employees> listEmp = EmployeeDA.ListEmployee();

            if (IsValidEmployeeData())
            {
                Employees Employees = new Employees();
                Employees.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
                Employees.FirstName = textBoxFirstName.Text;
                Employees.LastName = textBoxLastName.Text;
                Employees.JobTitle = comboBoxJobTitle.Text;
                Employees.HomePhone = maskedTextBoxPhone.Text;
                Employees.Email = textBoxEmail.Text;
                Employees.Status = comboBoxStatus.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    EmployeeDA.Update(Employees);
                    MessageBox.Show("Employee record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxEmployeeId.Enabled = true;
                }
            }
        }
        
        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (IsValidEmployeeData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    EmployeeDA.Delete(Convert.ToInt32(textBoxEmployeeId.Text));
                    MessageBox.Show("Employee record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxEmployeeId.Enabled = true;
                    EmployeeDA.ListEmployee(listViewEmployee);
                }
            }
        }
        private void buttonListEmployee_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            EmployeeDA.ListEmployee(listViewEmployee);
        }

        private void buttonSearchEmployee_Click_1(object sender, EventArgs e)
        {
            int choice = comboBoxSearchEmployee.SelectedIndex;
            switch (choice)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Employee ID
                    if (textBoxInfoEmployee.Text == "")
                    {
                        MessageBox.Show("You have to enter Employee ID, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    }
                    else
                    {
                        if (Validation.IsInteger(textBoxInfoEmployee))
                        {
                            Employees employee = EmployeeDA.Search(Convert.ToInt32(textBoxInfoEmployee.Text));
                            if (employee != null)
                            {
                                textBoxEmployeeId.Text = (employee.EmployeeId).ToString();
                                textBoxFirstName.Text = employee.FirstName;
                                textBoxLastName.Text = employee.LastName;
                                comboBoxJobTitle.Text = employee.JobTitle;
                                maskedTextBoxPhone.Text = employee.HomePhone;
                                textBoxEmail.Text = employee.Email;
                                comboBoxStatus.Text = employee.Status;
                                textBoxInfoEmployee.Clear();
                                textBoxEmployeeId.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Employee ID not found, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxInfoEmployee.Clear();
                                textBoxInfoEmployee.Focus();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //User Buttons

        private bool IsValidUserData()
        {
            return

               Validation.IsInteger(textBoxUserName)
               && Validation.IsValidPassword(textBoxPassword)
               && Validation.IsPresent(textBoxUserName) && Validation.IsPresent(textBoxPassword) && Validation.IsPresentComboBox(comboBoxJobTitle2);
        }
        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            List<Users> listU = UserDA.ListUser();

            if (IsValidUserData())
            {
                if (!Validation.IsUniqueUserID(listU, textBoxUserName.Text))
                {
                    MessageBox.Show(" DUPLICATE UserName", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxUserName.Clear();
                    textBoxUserName.Focus();
                    return;
                }
                else
                {
                    Employees employees = EmployeeDA.Search(Convert.ToInt32(textBoxUserName.Text));

                    string textEmployee = (textBoxUserName.Text);

                    if (employees == null)
                    {
                        MessageBox.Show("Wrong Information, you must enter a valid EmployeeID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxUserName.Clear();
                    }
                    else
                    {
                        Users aUser = new Users();
                        aUser.UserName = (textBoxUserName.Text);
                        aUser.Password = (textBoxPassword.Text);
                        aUser.UserJobTitle = comboBoxJobTitle2.Text;
                        UserDA.Add(aUser);
                        listU.Add(aUser);
                        ClearAll();
                        buttonListUser.Enabled = true;
                    }
                }
            }
        }
        private void buttonListUser_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            UserDA.ListUser(listViewUsers);
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            List<Users> listU = UserDA.ListUser();

            if (IsValidUserData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    UserDA.Delete(textBoxUserName.Text);
                    MessageBox.Show("User record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxUserName.Enabled = true;
                }
            }
        }
        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count > 0)
            {
                ListViewItem item = listViewUsers.SelectedItems[0];
                String UserName = listViewUsers.SelectedItems[0].SubItems[0].Text;
                String Password = listViewUsers.SelectedItems[0].SubItems[1].Text;
                String Jobtitle = listViewUsers.SelectedItems[0].SubItems[2].Text;
                textBoxUserName.Text = UserName;
                textBoxPassword.Text = Password;
                comboBoxJobTitle2.Text = Jobtitle;
            }
        }
        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            if (IsValidUserData())
            {
                Users user = new Users();
                user.UserName = textBoxUserName.Text;
                user.Password = textBoxPassword.Text;
                user.UserJobTitle = comboBoxJobTitle2.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    UserDA.Update(user);
                    MessageBox.Show("User record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxUserName.Enabled = true;
                }
            }
        }
        private void ClearAll()
        {
            textBoxEmployeeId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            comboBoxJobTitle.ResetText();
            maskedTextBoxPhone.Clear();
            textBoxEmail.Clear();
            comboBoxStatus.ResetText();
            textBoxEmployeeId.Focus();
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            comboBoxJobTitle2.ResetText();
            textBoxUserName.Focus();
        }
    }
}