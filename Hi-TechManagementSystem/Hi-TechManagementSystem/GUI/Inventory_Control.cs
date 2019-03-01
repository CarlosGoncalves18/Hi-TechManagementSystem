using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Hi_TechDistributionClassLibrary.Business;
using Hi_TechDistributionClassLibrary.DataAccess;
using Hi_TechDistributionClassLibrary.Validation;

namespace Hi_TechManagementSystem.GUI
{
    public partial class Inventory_Control : Form
    {
        public Inventory_Control()
        {
            InitializeComponent();
        }

        List<Author> listA = new List<Author>();
        List<Inventory> listB = new List<Inventory>();
        List<Publisher> listP = new List<Publisher>();

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
        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel4.Hide();
            panel1.Show();
        }
        private void buttoAddBook_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel4.Hide();
            panel2.Show();
        }
        private void buttonAddPublisher_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel4.Show();
        }

        //Author Buttons 

        private bool IsValidAuthorData()
        {
            return

            Validation.IsPresent(textBoxAuthorID) && Validation.IsPresent(textBoxFirstNameAuthor) && Validation.IsPresent(textBoxLastNameAuthor)
            && Validation.IsString(textBoxFirstNameAuthor) && Validation.IsString(textBoxLastNameAuthor) &&Validation.IsInteger(textBoxAuthorID)
            &&Validation.IsRightAuthorID(textBoxAuthorID);
        }

        private void buttonSaveAuthor_Click(object sender, EventArgs e)
        {
            List<Author> listA = AuthorDA.ListAuthor();

            if (IsValidAuthorData())
            {
                if (!Validation.IsUniqueAuthorID(listA, Convert.ToInt32(textBoxAuthorID.Text)))
                {
                    MessageBox.Show("Duplicate", "DUPLICATE Author ID");
                    textBoxAuthorID.Clear();
                    textBoxAuthorID.Focus();
                    return;
                }
                Author aAuthor = new Author();
                aAuthor.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                aAuthor.FirstName = textBoxFirstNameAuthor.Text;
                aAuthor.LastName = textBoxLastNameAuthor.Text;
                AuthorDA.Save(aAuthor);
                listA.Add(aAuthor);
                buttonListAuthor.Enabled = true;
                ClearAll();
            }
        }
        private void buttonListAuthor_Click(object sender, EventArgs e)
        {
            listViewAuthor.Items.Clear();
            AuthorDA.ListAuthor(listViewAuthor);
        }
        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (IsValidAuthorData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Author?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    AuthorDA.Delete(Convert.ToInt32(textBoxAuthorID.Text));
                    MessageBox.Show("Author record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxAuthorID.Enabled = true;
                }
            }
        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (IsValidAuthorData())
            {
                Author author = new Author();
                author.AuthorID = Convert.ToInt32(textBoxAuthorID.Text);
                author.FirstName = textBoxFirstNameAuthor.Text;
                author.LastName = textBoxLastNameAuthor.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    AuthorDA.Update(author);
                    MessageBox.Show("Author record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxAuthorID.Enabled = true;
                }
            }
        }
        
        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            {
                int choice = comboBoxAuthorInfo.SelectedIndex;
                switch (choice)
                {
                    case -1: // The user didn't select any search option
                        MessageBox.Show("Please select the search option");
                        break;
                    case 0:
                        if (textBoxAuthorInfo.Text == "")
                        {
                            MessageBox.Show("You have to enter Author ID, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Validation.IsInteger(textBoxAuthorInfo))
                            {
                                Author author = AuthorDA.Search(Convert.ToInt32(textBoxAuthorInfo.Text));
                        if (author != null)
                        {
                            textBoxAuthorID.Text = (author.AuthorID).ToString();
                            textBoxFirstNameAuthor.Text = author.FirstName;
                            textBoxLastNameAuthor.Text = author.LastName;
                            textBoxAuthorInfo.Clear();
                            textBoxAuthorID.Enabled = false;
                        }
                        else
                        {
                                    MessageBox.Show("Author not found, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxInfoPublisher.Clear();
                                    textBoxInfoPublisher.Focus();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        //Products Buttons 

        private bool IsValidInventoryData()
        {
            return

           Validation.IsPresent(textBoxISBN) && Validation.IsPresent(textBoxBookTitle) && Validation.IsPresent(textBoxYearPushlished)
           && Validation.IsPresent(textBoxBookPrice) && Validation.IsPresent(textBoxQuantityOnHand) && Validation.IsPresentComboBox(comboboxProductDescription)
           && Validation.IsPresentComboBox(comboBoxAuthorId) && Validation.IsPresentComboBox(comboBoxPublisherName) && Validation.IsInteger(textBoxISBN)
           && Validation.IsValidInformation(textBoxBookTitle) && Validation.IsInteger(textBoxYearPushlished) && Validation.IsDouble(textBoxBookPrice)
           && Validation.IsInteger(textBoxQuantityOnHand) && Validation.IsRightISBNID(textBoxISBN);
        }

        private void buttonSaveBook_Click(object sender, EventArgs e)
        {
            List<Inventory> listI = InventoryDA.ListInventory();

            if (IsValidInventoryData())
            {
                if (!Validation.IsUniqueISBN(listI, Convert.ToInt32(textBoxISBN.Text)))
                {
                    MessageBox.Show("Duplicate", "DUPLICATE Author ID");
                    textBoxISBN.Clear();
                    textBoxISBN.Focus();
                    return;
                }
                Inventory aProducts = new Inventory();
                aProducts.ISBNProduct = Convert.ToInt32(textBoxISBN.Text);
                aProducts.ProductTitle = textBoxBookTitle.Text;
                aProducts.ProductDescription = comboboxProductDescription.Text;
                aProducts.LastName = comboBoxAuthorId.Text;
                aProducts.PublisherName = comboBoxPublisherName.Text;
                aProducts.ProductYearPublished = Convert.ToInt32(textBoxYearPushlished.Text);
                aProducts.ProductQuantity = Convert.ToInt32(textBoxQuantityOnHand.Text);
                aProducts.ProductPrice = Convert.ToDouble(textBoxBookPrice.Text);
                InventoryDA.Save(aProducts);
                listB.Add(aProducts);
                buttonListBook.Enabled = true;
                ClearAll();
            }
        }

        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            List<Inventory> listI = InventoryDA.ListInventory();

            if (IsValidInventoryData())
            {
                Inventory aProducts = new Inventory();
                aProducts.ISBNProduct = Convert.ToInt32(textBoxISBN.Text);
                aProducts.ProductTitle = textBoxBookTitle.Text;
                aProducts.ProductDescription = comboboxProductDescription.Text;
                aProducts.AuthorID = Convert.ToInt32(comboBoxAuthorId.Text);
                aProducts.PublisherName = comboBoxPublisherName.Text;
                aProducts.ProductYearPublished = Convert.ToInt32(textBoxYearPushlished.Text);
                aProducts.ProductQuantity = Convert.ToInt32(textBoxQuantityOnHand.Text);
                aProducts.ProductPrice = Convert.ToDouble(textBoxBookPrice.Text);
                DialogResult ans = MessageBox.Show("Do you really want to update this Books?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    InventoryDA.Update(aProducts);
                    MessageBox.Show("Product record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxISBN.Enabled = true;
                }
            }
        }
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            int choice = comboBoxSearchBook.SelectedIndex;
            switch (choice)
            {
                case -1: // The user didn't select any search option
                    MessageBox.Show("Please select the search option");
                    break;
                case 0: //The user selected the search by Customer ID
                    Inventory products = InventoryDA.Search(Convert.ToInt32(textBoxInfoBook.Text));
                    if (products != null)
                    {
                        textBoxISBN.Text = Convert.ToString(products.ISBNProduct);
                        textBoxBookTitle.Text = products.ProductTitle;
                        comboboxProductDescription.Text = products.ProductDescription;
                        comboBoxAuthorId.Text = Convert.ToString(products.AuthorID);
                        comboBoxPublisherName.Text = products.PublisherName;
                        textBoxYearPushlished.Text = Convert.ToString(products.ProductYearPublished);
                        textBoxBookPrice.Text = Convert.ToString(products.ProductPrice);
                        textBoxQuantityOnHand.Text = Convert.ToString(products.ProductQuantity);
                        textBoxAuthorInfo.Clear();
                        textBoxISBN.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Product not Found!");
                        textBoxISBN.Clear();
                        textBoxISBN.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        private void buttonListBook_Click(object sender, EventArgs e)
        {
            listViewInventory.Items.Clear();
            InventoryDA.ListInventory(listViewInventory);
        }
        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            if (IsValidInventoryData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    InventoryDA.Delete(Convert.ToInt32(textBoxISBN.Text));
                    MessageBox.Show("Product record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxISBN.Enabled = true;
                }
            }
        }
        //Publisher Buttons 

        private bool IsValidPublisherData()
        {
            return

            Validation.IsPresent(textBoxPublisherName) && Validation.IsPresent(textBoxPublisherEmail) && Validation.IsPresent(textBoxAddressPublisher)
            && Validation.IsPresent(textBoxPublisherCity) && Validation.IsPresentComboBox(comboBoxPublisherCountry) 
            &&Validation.IsPresent(textBoxPublisherZipCode) && Validation.IsValidInformation(textBoxPublisherEmail) && Validation.IsValidInformation(textBoxAddressPublisher)
            &&Validation.IsString(textBoxPublisherCity) &&Validation.IsValidInformation(textBoxPublisherZipCode);
        }
        private void buttonSavePublisher_Click(object sender, EventArgs e)
        {
            List<Publisher> listP = PublisherDA.ListPublisher();

            if (IsValidPublisherData())
            {
                if (!Validation.IsUniquePublisherName(listP, textBoxPublisherName.Text))
                {
                    MessageBox.Show("Duplicate", "DUPLICATE Publisher Name");
                    textBoxPublisherName.Clear();
                    textBoxPublisherName.Focus();
                    return;
                }
                else
                {
                    Publisher aPublisher = new Publisher();
                    aPublisher.PublisherName = textBoxPublisherName.Text;
                    aPublisher.PublisherEmail = textBoxPublisherEmail.Text;
                    aPublisher.PublisherAddress = textBoxAddressPublisher.Text;
                    aPublisher.PublisherCity = textBoxPublisherCity.Text;
                    aPublisher.PublisherCountry = comboBoxPublisherCountry.Text;
                    aPublisher.PublisherZipCode = textBoxPublisherZipCode.Text;
                    PublisherDA.Save(aPublisher);
                    listP.Add(aPublisher);
                    buttonListAuthor.Enabled = true;
                    ClearAll();
                }
            }
        }

        private void buttonListPublisher_Click(object sender, EventArgs e)
        {
            listViewPublisher.Items.Clear();
            PublisherDA.ListPublisher(listViewPublisher);
        }

        private void buttonDeletePublisher_Click(object sender, EventArgs e)
        {
            if (IsValidPublisherData())
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete this Publisher?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    PublisherDA.Delete(textBoxPublisherName.Text);
                    MessageBox.Show("Publisher record has been deleted successfully", "Confirmation");
                    ClearAll();
                    textBoxPublisherName.Enabled = true;
                }
            }
        }
        private void buttonUpdatePublisher_Click(object sender, EventArgs e)
        {
            List<Publisher> listP = PublisherDA.ListPublisher();

            if (IsValidPublisherData())
            {
                Publisher publisher = new Publisher();
                publisher.PublisherName = textBoxPublisherName.Text;
                publisher.PublisherEmail = textBoxPublisherEmail.Text;
                publisher.PublisherAddress = textBoxAddressPublisher.Text;
                DialogResult ans = MessageBox.Show("Do you really want to update this Publisher?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ans == DialogResult.Yes)
                {
                    PublisherDA.Update(publisher);
                    MessageBox.Show("Publisher record has been updated successfully", "Confirmation");
                    ClearAll();
                    textBoxPublisherName.Enabled = true;
                }
            }
        }

        private void buttonSearchPublisher_Click(object sender, EventArgs e)
        {
            {
                int choice = (comboBoxSearchPublisher.SelectedIndex);
                switch (choice)
                {
                    case -1: // The user didn't select any search option
                        MessageBox.Show("Please select the search option");
                        break;
                    case 0: //The user selected the search by Customer ID
                        if (textBoxInfoPublisher.Text == "")
                        {
                            MessageBox.Show("You have to enter Publisher Name, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Validation.IsValidInformation(textBoxInfoPublisher))
                            {
                                Publisher publisher = PublisherDA.Search(textBoxInfoPublisher.Text);
                                if (publisher != null)
                                {
                                    textBoxPublisherName.Text = (publisher.PublisherName).ToString();
                                    textBoxAddressPublisher.Text = publisher.PublisherAddress;
                                    textBoxPublisherEmail.Text = publisher.PublisherEmail;
                                    textBoxPublisherCity.Text = publisher.PublisherCity;
                                    comboBoxPublisherCountry.Text = publisher.PublisherCountry;
                                    textBoxPublisherZipCode.Text = publisher.PublisherZipCode;
                                    textBoxInfoPublisher.Clear();
                                    textBoxAuthorID.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Publisher not found, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxInfoPublisher.Clear();
                                    textBoxInfoPublisher.Focus();
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
            textBoxAuthorID.Clear();
            textBoxFirstNameAuthor.Clear();
            textBoxLastNameAuthor.Clear();
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            comboboxProductDescription.ResetText();
            comboBoxAuthorId.ResetText();
            comboBoxPublisherName.ResetText();
            textBoxYearPushlished.Clear();
            textBoxBookPrice.Clear();
            textBoxQuantityOnHand.Clear();
            comboBoxAuthorInfo.ResetText();
            textBoxAuthorInfo.Clear();
            textBoxPublisherName.Clear();
            textBoxPublisherEmail.Clear();
            textBoxAddressPublisher.Clear();
            comboBoxSearchPublisher.ResetText();
            textBoxPublisherCity.Clear();
            comboBoxPublisherCountry.ResetText();
            textBoxPublisherZipCode.Clear();
            textBoxInfoPublisher.Clear();
            textBoxAuthorID.Focus();
            textBoxISBN.Focus();
            textBoxPublisherName.Focus();
        }

        private void Inventory_Control_Load(object sender, EventArgs e)
        {
            PublisherDA.Comboboxlist(comboBoxPublisherName);
            AuthorDA.Comboboxlist(comboBoxAuthorId);
        }

    }
}