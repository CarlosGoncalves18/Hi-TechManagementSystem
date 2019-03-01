using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_TechDistributionClassLibrary.Business;
using System.IO;
using System.Windows.Forms;

namespace Hi_TechDistributionClassLibrary.DataAccess
{
    public static class InventoryDA
    {
        private static string filePath = Application.StartupPath + @"\Inventory.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp3.dat";

        public static void Save(Inventory products)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(products.ISBNProduct + "|" + products.ProductTitle + "|" + products.ProductDescription
                + "|" + products.AuthorID + "|" + products.PublisherName + "|" + products.ProductYearPublished + "|" +
                + products.ProductPrice + "|" + products.ProductQuantity);
            sWriter.Close();
            MessageBox.Show("Product Data has been saved.");
        }
        public static void ListInventory(ListView listViewInventory)
        {
            StreamReader sReader = new StreamReader(filePath);
            listViewInventory.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                listViewInventory.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static void ListOrderInventory(ListView listViewOrderInventory)
        {
            StreamReader sReader = new StreamReader(filePath);
            listViewOrderInventory.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);                          
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                listViewOrderInventory.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static List<Inventory> ListInventory()
        {
            List<Inventory> listI = new List<Inventory>();
            StreamReader sReader = new StreamReader(filePath);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Inventory products = new Inventory();
                products.ISBNProduct = Convert.ToInt32(fields[0]);
                products.ProductTitle = fields[1];
                products.ProductDescription = fields[2];
                products.LastName = fields[3];
                products.PublisherName = fields[4];
                products.ProductYearPublished = Convert.ToInt32(fields[5]);
                products.ProductPrice = Convert.ToDouble(fields[6]);
                products.ProductQuantity = Convert.ToInt32(fields[7]);
                listI.Add(products);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listI;
        }
        public static Inventory Search(int isbn)
        {
            Inventory products = new Inventory();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (isbn == Convert.ToInt32(fields[0]))
                {
                    products.ISBNProduct = Convert.ToInt32(fields[0]);
                    products.ProductTitle = fields[1];
                    products.ProductDescription = fields[2];
                    products.LastName = fields[3];
                    products.PublisherName = fields[4];
                    products.ProductYearPublished = Convert.ToInt32(fields[5]);
                    products.ProductPrice = Convert.ToDouble(fields[6]);
                    products.ProductQuantity = Convert.ToInt32(fields[7]);
                    sReader.Close();
                    return products;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int isbn)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((isbn) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]
                        + "|" + fields[3] + "|" + fields[4] + "|" + fields[5] + "|" + fields[6] + "|" + fields[7]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
        public static void Update(Inventory products)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Convert.ToInt32(fields[0]) != (products.AuthorID)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]
                        + "|" + fields[3] + "|" + fields[4] + "|" + fields[5] + "|" + fields[6] + "|" + fields[7]);
                }

                line = sReader.ReadLine();      
            }
            sWriter.WriteLine(products.ISBNProduct + "|" + products.ProductTitle + "|" + products.ProductDescription
                + "|" + products.AuthorID + "|" + products.PublisherName + "|" + products.ProductYearPublished + "|" +
                +products.ProductPrice + "|" + products.ProductQuantity);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}