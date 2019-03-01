using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_TechDistributionClassLibrary.Business;
using Hi_TechDistributionClassLibrary.DataAccess;


namespace Hi_TechDistributionClassLibrary.Validation
{
    public class Validation
    {
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + "You must fill out all of the boxes, try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsPresentComboBox(ComboBox textBox)
        {
            if (textBox.Text == "")
            {

                MessageBox.Show(textBox.Tag + "You must fill out all of the boxes, try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsInteger(TextBox textBox)
        {
            int number = 0;
            if (int.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " Must be a Number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();

                return false;
            }
        }
        public static bool IsRightNumber(TextBox textBox)
        {
            int number = Convert.ToInt32(textBox.Text);

            if (!(number.ToString().Length == 5))
            {

                MessageBox.Show(textBox.Tag + " Must be 5 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsNotDuplicated(TextBox textBox, List<Employees> listE)
        {
            bool found = false;
            foreach (Employees e in listE)
            {
                if (e.EmployeeId == Convert.ToInt32(textBox.Text))
                {
                    found = true;
                }
            }
            if (found)
            {
                MessageBox.Show(textBox.Tag + " DUPLICATE ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsString(TextBox textBox)
        {

            if (Regex.IsMatch(textBox.Text, @"^[A-Za-z]*$"))
            {
                return true;
            }
            else

                MessageBox.Show(textBox.Tag + "Please enter a valid information", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox.Text = "";
            textBox.Focus();
            return false;
        }
        public static bool IsUniqueEmployeeID(List<Employees> listEmp, int id)
        {
            foreach (Employees e in listEmp)
            {
                if (e.EmployeeId == id)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidPassword(TextBox txtInput)
        {

            if ((txtInput.TextLength) != 8)
            {
                MessageBox.Show(" Must be 8 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtInput.Clear();
                txtInput.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsUniqueUserID(List<Users> listU, string id)
        {
            foreach (Users u in listU)
            {
                if (u.UserName == id)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsRightClientNumber(TextBox textBox)
        {
            int number = Convert.ToInt32(textBox.Text);

            if (!(number.ToString().Length == 6))
            {

                MessageBox.Show(textBox.Tag + " Must be 6 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsUniqueClientID(List<Client> listC, int id)
        {
            foreach (Client c in listC)
            {
                if (c.ClientID == id)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsUniqueClientName(List<Client> listC, string name)
        {
            foreach (Client c in listC)
            {
                if (c.InstitutionName == name)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsUniquePublisherName(List<Publisher> listP, string pn)
        {
            foreach (Publisher p in listP)
            {
                if (p.PublisherName == pn)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidInformation(TextBox txtInput)
        {
            for (int i = 0; i < txtInput.TextLength; i++)
            {
                if ((char.IsLetterOrDigit(txtInput.Text, i) && (!char.IsWhiteSpace(txtInput.Text, i))))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Wrong Information", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtInput.Clear();
                    txtInput.Focus();                  
                }             
            }
            return false;
        }
        public static bool IsUniqueAuthorID(List<Author> listA, int id)
        {
            foreach (Author a in listA)
            {
                if (a.AuthorID == id)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsRightAuthorID(TextBox textBox)
        {
            int number = Convert.ToInt32(textBox.Text);

            if (!(number.ToString().Length == 3))
            {

                MessageBox.Show(textBox.Tag + " Must be 3 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsDouble(TextBox textBox)
        {
            double number = 0.0;
            if (double.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " Must be a Number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();

                return false;
            }
        }
        public static bool IsUniqueISBN(List<Inventory> listI, int isbn)
        {
            foreach (Inventory i in listI)
            {
                if (i.ISBNProduct == isbn)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsRightISBNID(TextBox textBox)
        {
            int number = Convert.ToInt32(textBox.Text);

            if (!(number.ToString().Length == 6))
            {

                MessageBox.Show(textBox.Tag + " Must be 6 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
    