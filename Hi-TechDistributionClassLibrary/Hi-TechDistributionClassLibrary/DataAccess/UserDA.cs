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
    public static class UserDA
    {
        private static string filePath = Application.StartupPath + @"\User.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Add(Users user)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(user.UserName + "|" + user.Password + "|" + user.UserJobTitle);
            sWriter.Close();
            MessageBox.Show("User Data has been saved.");
        }
        public static void ListUser(ListView listViewUser)
        {
            StreamReader sReader = new StreamReader(filePath);
            listViewUser.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                listViewUser.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static List<Users> ListUser()
        {
            List<Users> listU = new List<Users>();
            StreamReader sReader = new StreamReader(filePath);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Users user = new Users();
                user.UserName = fields[0];
                user.Password = fields[1];
                user.UserJobTitle = fields[2];
                listU.Add(user);
                line = sReader.ReadLine();
            }
            sReader.Close();
            return listU;
        }
        public static Users Search(string Username)
        {
            Users user = new Users();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (Username == (fields[0]))
                {
                    user.UserName = fields[0];
                    user.Password = fields[1];
                    user.UserJobTitle = fields[2];
                    sReader.Close();
                    return user;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(string Username)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Username) != ((fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
        public static void Update(Users user)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                if (fields[0] != (user.UserName))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]);
                }

                line = sReader.ReadLine();
            }
            sWriter.WriteLine(user.UserName + "|" + user.Password + "|" + user.UserJobTitle);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}