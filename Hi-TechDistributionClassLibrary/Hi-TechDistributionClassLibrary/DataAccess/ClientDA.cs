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
    public static class ClientDA
    {
        private static string filePath = Application.StartupPath + @"\Client.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Client client)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(client.ClientID + "|" + client.InstitutionName + "|" + client.InstitutionAddress + "|" + 
                client.InstitutionCity + "|" + client.InstitutionZipCode + "|" + client.InstitutionPhoneNumber + "|" + 
                client.InstitutionEmail);
            sWriter.Close();
            MessageBox.Show("Client Data has been saved.");
        }
        public static void ListClient(ListView listViewClient)
        {
            StreamReader sReader = new StreamReader(filePath);
            listViewClient.Items.Clear();
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
                listViewClient.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static void Comboboxlist(ComboBox combo)
        {
            StreamReader sReader = new StreamReader(filePath);
            combo.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                combo.Items.Add(fields[0]);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static List<Client> ListClient()
        {
            List<Client> listC = new List<Client>();
            StreamReader sReader = new StreamReader(filePath);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Client client = new Client();
                client.ClientID = Convert.ToInt32(fields[0]);
                client.InstitutionName = fields[1];
                client.InstitutionAddress = fields[2];
                client.InstitutionCity = fields[3];
                client.InstitutionZipCode = fields[4];
                client.InstitutionPhoneNumber = fields[5];
                client.InstitutionEmail = fields[6];
                listC.Add(client);
                line = sReader.ReadLine();
            }
            sReader.Close(); 
            return listC;
        }
        public static Client Search(int clientId)
        {
            Client client = new Client();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (clientId == Convert.ToInt32(fields[0]))
                {
                    client.ClientID = Convert.ToInt32(fields[0]);
                    client.InstitutionName = fields[1];
                    client.InstitutionAddress = fields[2];
                    client.InstitutionCity = fields[3];
                    client.InstitutionZipCode = fields[4];
                    client.InstitutionPhoneNumber = fields[5];
                    client.InstitutionEmail = fields[6];
                    sReader.Close();
                    return client;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int clientId)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((clientId) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4]
                         + "|" + fields[5] + "|" + fields[6]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
        public static void Update(Client client)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Convert.ToInt32(fields[0]) != (client.ClientID)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4]
                         + "|" + fields[5] + "|" + fields[6]);
                }

                line = sReader.ReadLine();    
            }
            sWriter.WriteLine(client.ClientID + "|" + client.InstitutionName + "|" + client.InstitutionAddress + "|" +
                client.InstitutionCity + "|" + client.InstitutionZipCode + "|" + client.InstitutionPhoneNumber + "|" + 
                client.InstitutionEmail);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
       
    }
}
