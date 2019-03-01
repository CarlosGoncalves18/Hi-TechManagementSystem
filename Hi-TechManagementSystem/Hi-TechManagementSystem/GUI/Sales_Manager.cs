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
    public partial class Sales_Manager : Form
    {
        public Sales_Manager()
        {
            InitializeComponent();
        }

        List<Client> listC = new List<Client>();

        private bool IsValidClientData()
        {
            return

               Validation.IsInteger(textBoxClientID)
               && Validation.IsRightClientNumber(textBoxClientID)
               && Validation.IsPresent(textBoxClientID) && Validation.IsPresent(textBoxInstitutionName) && Validation.IsPresent(textBoxEmailClient)
               && Validation.IsPresent(textBoxInstitutionAddress) && Validation.IsPresent(textBoxInstitutionCity) && Validation.IsPresent(textBoxZipCode)
               && Validation.IsString(textBoxInstitutionCity) && Validation.IsValidInformation(textBoxEmailClient) 
               &&Validation.IsValidInformation(textBoxInstitutionName) && Validation.IsValidInformation(textBoxInstitutionAddress);
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }
        private void buttonSaveClient_Click(object sender, EventArgs e)
        {
            List<Client> listC = ClientDA.ListClient();

            if (IsValidClientData())
            {
                if (!Validation.IsUniqueClientID(listC, Convert.ToInt32(textBoxClientID.Text)))
                {
                    MessageBox.Show(" DUPLICATE ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxClientID.Clear();
                    textBoxClientID.Focus();
                    return;
                }
                if (!Validation.IsUniqueClientName(listC, textBoxInstitutionName.Text))
                {
                    MessageBox.Show(" DUPLICATE ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxInstitutionName.Clear();
                    textBoxInstitutionName.Focus();
                    return;
                }
                else
                {
                    Client aClient = new Client();
                    aClient.ClientID = Convert.ToInt32(textBoxClientID.Text);
                    aClient.InstitutionName = textBoxInstitutionName.Text;
                    aClient.InstitutionAddress = textBoxInstitutionAddress.Text;
                    aClient.InstitutionCity = textBoxInstitutionCity.Text;
                    aClient.InstitutionZipCode = textBoxZipCode.Text;
                    aClient.InstitutionPhoneNumber = maskedTextBoxPhoneClient.Text;
                    aClient.InstitutionEmail = textBoxEmailClient.Text;
                    ClientDA.Save(aClient);
                    listC.Add(aClient);
                    buttonListClient.Enabled = true;
                    ClearAll();
                }
            }
        }      
        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (IsValidClientData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    ClientDA.Delete(Convert.ToInt32(textBoxClientID.Text));
                    MessageBox.Show("Client record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxClientID.Focus();
                    textBoxClientID.Enabled = true;
                }
            }
        }
        private void buttonUpdateClient_Click(object sender, EventArgs e)
        {
            List<Client> listC = ClientDA.ListClient();

            if (IsValidClientData())
            {
                Client Client = new Client();
                Client.ClientID = Convert.ToInt32(textBoxClientID.Text);
                Client.InstitutionName = textBoxInstitutionName.Text;
                Client.InstitutionAddress = textBoxInstitutionAddress.Text;
                Client.InstitutionCity = textBoxInstitutionCity.Text;
                Client.InstitutionZipCode = textBoxZipCode.Text;
                Client.InstitutionPhoneNumber = maskedTextBoxPhoneClient.Text;
                Client.InstitutionEmail = textBoxEmailClient.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    ClientDA.Update(Client);
                    MessageBox.Show("Client record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxClientID.Enabled = true;
                }
            }
        }
        
        private void buttonListClient_Click(object sender, EventArgs e)
        {
            listViewClient.Items.Clear();
            ClientDA.ListClient(listViewClient);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            {
                int choice = comboBoxSearchClient.SelectedIndex;
                switch (choice)
                {
                    case -1: // The user didn't select any search option
                        MessageBox.Show("Please select the search option");
                        break;
                    case 0: //The user selected the search by Customer ID
                        if (textBoxInfoClient.Text == "")
                        {
                            MessageBox.Show("You have to enter Client ID, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Validation.IsInteger(textBoxInfoClient))
                            {
                                Client client = ClientDA.Search(Convert.ToInt32(textBoxInfoClient.Text));
                                if (client != null)
                                {
                                    textBoxClientID.Text = (client.ClientID).ToString();
                                    textBoxInstitutionName.Text = client.InstitutionName;
                                    textBoxInstitutionAddress.Text = client.InstitutionAddress;
                                    textBoxInstitutionCity.Text = client.InstitutionCity;
                                    textBoxZipCode.Text = client.InstitutionZipCode;
                                    textBoxEmailClient.Text = client.InstitutionEmail;
                                    maskedTextBoxPhoneClient.Text = client.InstitutionPhoneNumber;
                                    textBoxInfoClient.Clear();
                                    textBoxClientID.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Client ID not found, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxInfoClient.Clear();
                                    textBoxInfoClient.Focus();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }          
        private void ClearAll()
        {
            textBoxClientID.Clear();
            textBoxInstitutionName.Clear();
            textBoxInstitutionAddress.Clear();
            textBoxInstitutionCity.Clear();
            textBoxZipCode.Clear();
            textBoxEmailClient.Clear();
            maskedTextBoxPhoneClient.Clear();
            textBoxClientID.Focus();
        }
    }
}