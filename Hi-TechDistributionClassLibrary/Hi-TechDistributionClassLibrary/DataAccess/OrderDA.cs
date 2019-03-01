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
    public static class OrderDA
    {
        private static string filePathOrder = Application.StartupPath + @"\Order.dat";
        private static string fileTempOrder = Application.StartupPath + @"\Temp6.dat";

        public static void Save(Orders order)
        {
            StreamWriter sWriter = new StreamWriter(filePathOrder, true);
            sWriter.WriteLine(order.OrderNumber + "|" + order.ISBNProduct + "|" + order.ProductTitle + "|" +
                order.ProductDescription + "|" + order.ClientID + "|" + order.ClientName + "|" + order.OrderDate + "|" +
                order.ShippingDate + "|" + order.OrderQuantity + "|" + order.ProductPrice + "|" + order.FinalAmount);
            sWriter.Close();
            MessageBox.Show("Order Data has been saved.");
        }
        public static void ListOrder(ListView listViewOrder)
        {
            StreamReader sReader = new StreamReader(filePathOrder);
            listViewOrder.Items.Clear();
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
                item.SubItems.Add(fields[8]);
                item.SubItems.Add(fields[9]);
                item.SubItems.Add(fields[10]);
                listViewOrder.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static List<Orders> ListOrder()
        {
            List<Orders> listO = new List<Orders>();
            StreamReader sReader = new StreamReader(filePathOrder);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');

                Orders order = new Orders();
                order.OrderNumber = Convert.ToInt32(fields[0]);
                order.ISBNProduct = Convert.ToInt32(fields[1]);
                order.ProductTitle = fields[2];
                order.ProductDescription = fields[3];
                order.ClientID = Convert.ToInt32(fields[4]);
                order.ClientName = fields[5];
                order.OrderDate = fields[6];
                order.ShippingDate = fields[7];
                order.OrderQuantity = Convert.ToInt32(fields[8]);
                order.ProductPrice = Convert.ToDouble(fields[9]);
                order.FinalAmount = Convert.ToDouble(fields[10]);
                listO.Add(order);
                line = sReader.ReadLine();

            }
            sReader.Close(); //Close the file
            return listO;
        }
        public static Orders Search(int ordern)
        {
            Orders order = new Orders();

            StreamReader sReader = new StreamReader(filePathOrder);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (ordern == Convert.ToInt32(fields[0]))
                {
                    order.OrderNumber = Convert.ToInt32(fields[0]);
                    order.ISBNProduct = Convert.ToInt32(fields[1]);
                    order.ProductTitle = fields[2];
                    order.ProductDescription = fields[3];
                    order.ClientID = Convert.ToInt32(fields[4]);
                    order.ClientName = fields[5];
                    order.OrderDate = fields[6];
                    order.ShippingDate = fields[7];
                    order.OrderQuantity = Convert.ToInt32(fields[8]);
                    order.ProductPrice = Convert.ToDouble(fields[9]);
                    order.FinalAmount = Convert.ToDouble(fields[10]);
                    sReader.Close();
                    return order;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(string ordern)
        {
            StreamReader sReader = new StreamReader(filePathOrder);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempOrder, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((ordern) != ((fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4]
                    + "|" + fields[5] + "|" + fields[6] + "|" + fields[7] + "|" + fields[8] + "|" + fields[9] + "|" + fields[10]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathOrder);
            File.Move(fileTempOrder, filePathOrder);
        }
        public static void Update(Orders order)
        {
            StreamReader sReader = new StreamReader(filePathOrder);
            StreamWriter sWriter = new StreamWriter(fileTempOrder, true);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Convert.ToInt32(fields[0]) != (order.OrderNumber)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4]
                    + "|" + fields[5] + "|" + fields[6] + "|" + fields[7] + "|" + fields[8] + "|" + fields[9] + "|" + fields[10]);
                }

                line = sReader.ReadLine();
            }
            sWriter.WriteLine(order.OrderNumber + "|" + order.ISBNProduct + "|" + order.ProductTitle + "|" +
                    order.ProductDescription + "|" + order.ClientID + "|" + order.ClientName + "|" + order.OrderDate + "|" +
                    order.ShippingDate + "|" + order.OrderQuantity + "|" + order.ProductPrice + "|" + order.FinalAmount);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathOrder);
            File.Move(fileTempOrder, filePathOrder);
        }
    }
}