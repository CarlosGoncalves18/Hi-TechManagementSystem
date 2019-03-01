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
    public class PublisherDA
    {
        private static string filePathPublisher = Application.StartupPath + @"\Publisher.dat";
        private static string fileTempPublisher = Application.StartupPath + @"\Temp5.dat";

        public static void Save(Publisher publisher)
        {
            StreamWriter sWriter = new StreamWriter(filePathPublisher, true);
            sWriter.WriteLine(publisher.PublisherName + "|" + publisher.PublisherEmail + "|" + publisher.PublisherAddress
                + "|" + publisher.PublisherCity + "|" + publisher.PublisherCountry + "|" + publisher.PublisherZipCode);
            sWriter.Close();
            MessageBox.Show("Publisher Data has been saved.");
        }
        public static void ListPublisher(ListView listViewPublisher)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            listViewPublisher.Items.Clear();
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
                listViewPublisher.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static void Comboboxlist(ComboBox combo)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            combo.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                // ComboBox item = new ComboBox(fields[1]);
                combo.Items.Add(fields[0]);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Publisher> ListPublisher()
        {
            List<Publisher> listP = new List<Publisher>();
            StreamReader sReader = new StreamReader(filePathPublisher);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Publisher publisher = new Publisher();
                publisher.PublisherName = fields[0];
                publisher.PublisherEmail = fields[1];
                publisher.PublisherAddress = fields[2];
                publisher.PublisherCity = fields[3];
                publisher.PublisherCountry = fields[4];
                publisher.PublisherZipCode = fields[5];
                listP.Add(publisher);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listP;
        }
     
        public static Publisher Search(string pname)
        {
            Publisher publisher = new Publisher();

            StreamReader sReader = new StreamReader(filePathPublisher);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (pname == fields[0])
                {
                    publisher.PublisherName = fields[0];
                    publisher.PublisherEmail = fields[1];
                    publisher.PublisherAddress = fields[2];
                    publisher.PublisherCity = fields[3];
                    publisher.PublisherCountry = fields[4];
                    publisher.PublisherZipCode = fields[5];
                    sReader.Close();
                    return publisher;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(string pname)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempPublisher, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((pname) != fields[0])
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3]
                        + "|" + fields[4] + "|" + fields[5]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathPublisher);
            File.Move(fileTempPublisher, filePathPublisher);
        }
        public static void Update(Publisher publisher)
        {
            StreamReader sReader = new StreamReader(filePathPublisher);
            StreamWriter sWriter = new StreamWriter(fileTempPublisher, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (((fields[0]) != (publisher.PublisherName)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3]
                        + "|" + fields[4] + "|" + fields[5]);
                }

                line = sReader.ReadLine();// Attention : read the next line        
            }
            sWriter.WriteLine(publisher.PublisherName + "|" + publisher.PublisherEmail + "|" + publisher.PublisherAddress
                + "|" + publisher.PublisherCity + "|" + publisher.PublisherCountry + "|" + publisher.PublisherZipCode);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathPublisher);
            File.Move(fileTempPublisher, filePathPublisher);
        }
    }
}