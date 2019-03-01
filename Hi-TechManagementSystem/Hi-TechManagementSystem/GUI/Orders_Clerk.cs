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
using System.Security.Cryptography;
using Hi_TechDistributionClassLibrary.Validation;

namespace Hi_TechManagementSystem.GUI
{
    public partial class Orders_Clerk : Form
    {
        public Orders_Clerk()
        {
            InitializeComponent();
            listViewOrder.Items.Clear();
        }

        List<Orders> listO = new List<Orders>();
        List<Client> listC = new List<Client>();
        List<Inventory> listI = new List<Inventory>();

        private bool IsValidOrderData()
        {
            return

               Validation.IsInteger(textBoxOQty)
               && Validation.IsPresent(textBoxOQty) && Validation.IsPresent(textBoxISBN) && Validation.IsPresentComboBox(comboBoxClientID);
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form2 = new Login();
            form2.Show();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to logout the application?", "Confirmation",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void buttonSaveOrder_Click_1(object sender, EventArgs e)
        {
            List<Orders> listO = OrderDA.ListOrder();
            if (IsValidOrderData())
            {
               
                Inventory product = InventoryDA.Search(Convert.ToInt32(textBoxISBN.Text));
                Client client = ClientDA.Search(Convert.ToInt32(comboBoxClientID.Text));
                string isbn = textBoxISBN.Text;
                int quantityproduct = Convert.ToInt32(textBoxOQty.Text);
                int id = (Convert.ToInt32(comboBoxClientID.Text));

                if (product == null)
                {
                    MessageBox.Show("Wrong Information product, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (product.ProductQuantity < Convert.ToInt32(textBoxOQty.Text))
                {
                    MessageBox.Show("We do not have the quantity required on Inventory", "Missing Product");
                    textBoxOQty.Clear();
                    return;
                }
                else
                {
                    if (client.ClientID == (Convert.ToInt32(comboBoxClientID.Text)))
                    {
                        textBoxClientName.Text = client.InstitutionName;
                    }

                    Int32 quantityselected = Convert.ToInt32(textBoxOQty.Text);
                    Double priceselected = Convert.ToDouble(textBoxProductPrice.Text);
                    Double finalamout = quantityselected * priceselected;
                    textBoxFinalAmount.Text = finalamout.ToString();
                    Orders aOrder = new Orders();
                    aOrder.OrderNumber = Convert.ToInt32(textBoxOnumber.Text);
                    aOrder.ISBNProduct = Convert.ToInt32(textBoxISBN.Text);
                    aOrder.ProductTitle = textBoxOProductTitle.Text;
                    aOrder.ProductDescription = textBoxProductDescription.Text;
                    aOrder.ClientID = (Convert.ToInt32(comboBoxClientID.Text));
                    aOrder.ClientName = textBoxClientName.Text;
                    aOrder.OrderDate = dateTimePickerOdate.Text;
                    aOrder.ShippingDate = dateTimePickerSDate.Text;
                    aOrder.OrderQuantity = Convert.ToInt32(textBoxOQty.Text);
                    aOrder.ProductPrice = Convert.ToDouble(textBoxProductPrice.Text);
                    aOrder.FinalAmount = Convert.ToDouble(textBoxFinalAmount.Text);
                    OrderDA.Save(aOrder);
                    listO.Add(aOrder);
                    ClearAll();
                }
            }
        }
        private void buttonListOrder_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            OrderDA.ListOrder(listViewOrder);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 19999);
            textBoxOnumber.Text = randomNumber.ToString();
            textBoxOnumber.Clear();
            ClearAll();
            Random random2 = new Random();
            int randomNumber2 = random.Next(10000, 19999);
            textBoxOnumber.Text = randomNumber.ToString();
        }
        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            {
                int choice = comboBoxSearchOrder.SelectedIndex;
                switch (choice)
                {
                    case -1: // The user didn't select any search option
                        MessageBox.Show("Please select the search option");
                        break;
                    case 0: //The user selected the search by Customer ID
                        Orders orders = OrderDA.Search(Convert.ToInt32(textBoxInfoOrder.Text));
                        if (orders != null)
                        {
                            textBoxOnumber.Text = (orders.OrderNumber).ToString();
                            textBoxISBN.Text = (orders.ISBNProduct).ToString();
                            textBoxOProductTitle.Text = orders.ProductTitle;
                            textBoxProductDescription.Text = orders.ProductDescription;
                            comboBoxClientID.Text = orders.ClientName;
                            dateTimePickerOdate.Text = orders.OrderDate;
                            dateTimePickerSDate.Text = orders.ShippingDate;
                            textBoxOQty.Text = orders.OrderQuantity.ToString();
                            textBoxProductPrice.Text = orders.ProductPrice.ToString();
                            textBoxFinalAmount.Text = orders.FinalAmount.ToString();
                            textBoxInfoOrder.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Order not Found!");
                            textBoxInfoOrder.Clear();
                            textBoxInfoOrder.Focus();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void buttonUpdateOrder_Click(object sender, EventArgs e)
        {
            List<Orders> listO = OrderDA.ListOrder();

            if (IsValidOrderData())
            {
                Orders aOrder = new Orders();
                aOrder.OrderNumber = Convert.ToInt32(textBoxOnumber.Text);
                aOrder.ISBNProduct = Convert.ToInt32(textBoxISBN.Text);
                aOrder.ProductTitle = textBoxOProductTitle.Text;
                aOrder.ProductDescription = textBoxProductDescription.Text;
                aOrder.ClientName = comboBoxClientID.Text;
                aOrder.OrderDate = dateTimePickerOdate.Text;
                aOrder.ShippingDate = dateTimePickerSDate.Text;
                aOrder.OrderQuantity = Convert.ToInt32(textBoxOQty.Text);
                aOrder.ProductPrice = Convert.ToDouble(textBoxProductPrice.Text);
                aOrder.FinalAmount = Convert.ToDouble(textBoxFinalAmount.Text);
                DialogResult ans = MessageBox.Show("Do you really want to update this Order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    OrderDA.Update(aOrder);
                    MessageBox.Show("Order record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxOnumber.Focus();
                }
            }
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (IsValidOrderData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    OrderDA.Delete(textBoxOnumber.Text);
                    MessageBox.Show("Order record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxOnumber.Focus();
                }
            }
        }
        private void listViewOrderInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrderInventory.SelectedIndices.Count > 0)
            {
                ListViewItem item = listViewOrderInventory.SelectedItems[0];
                String ISBN = listViewOrderInventory.SelectedItems[0].SubItems[0].Text;
                String ProductTitle = listViewOrderInventory.SelectedItems[0].SubItems[1].Text;
                String ProductDescription = listViewOrderInventory.SelectedItems[0].SubItems[2].Text;
                String ProductPrice = listViewOrderInventory.SelectedItems[0].SubItems[3].Text;
                String QuantityonHand = listViewOrderInventory.SelectedItems[0].SubItems[4].Text;
                textBoxISBN.Text = ISBN;
                textBoxOProductTitle.Text = ProductTitle;
                textBoxProductDescription.Text = ProductDescription;
                textBoxProductPrice.Text = ProductPrice;
            }
        }
        private void ClearAll()
        {
            textBoxISBN.Clear();
            textBoxOProductTitle.Clear();
            textBoxProductDescription.Clear();
            textBoxISBN.Clear();
            textBoxClientName.Clear();
            comboBoxClientID.ResetText();
            textBoxOQty.Clear();
            textBoxProductPrice.Clear();
            textBoxFinalAmount.Clear();
            textBoxISBN.Focus();
        }

        private void Orders_Clerk_Load(object sender, EventArgs e)
        {
            InventoryDA.ListOrderInventory(listViewOrderInventory);
            Random random = new Random();
            int randomNumber = random.Next(10000, 19999);
            textBoxOnumber.Text = randomNumber.ToString();
            ClientDA.Comboboxlist(comboBoxClientID);
        }
    }
}