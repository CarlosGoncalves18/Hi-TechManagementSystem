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
    public static class AuthorDA
    {
        private static string filePathAuthor = Application.StartupPath + @"\Author.dat";
        private static string fileTempAuthor = Application.StartupPath + @"\Temp4.dat";

        public static void Save(Author author)
        {
            StreamWriter sWriter = new StreamWriter(filePathAuthor, true);
            sWriter.WriteLine(author.AuthorID + "|" + author.FirstName + "|"
            + author.LastName);
            sWriter.Close();
            MessageBox.Show("Author Data has been saved.");
        }
        public static void ListAuthor(ListView listViewAuthor)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            listViewAuthor.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);                
                listViewAuthor.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static void Comboboxlist(ComboBox combo)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            combo.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                combo.Items.Add(fields[2]);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }
        public static List<Author> ListAuthor()
        {
            List<Author> listA = new List<Author>();
            StreamReader sReader = new StreamReader(filePathAuthor);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Author author = new Author();
                author.AuthorID = Convert.ToInt32(fields[0]);
                author.FirstName = fields[1];
                author.LastName = fields[2];
                listA.Add(author);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listA;
        }
        public static Author Search(int authorId)
        {
            Author author = new Author();

            StreamReader sReader = new StreamReader(filePathAuthor);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (authorId == Convert.ToInt32(fields[0]))
                {
                    author.AuthorID = Convert.ToInt32(fields[0]);
                    author.FirstName = fields[1];
                    author.LastName = fields[2];                   
                    sReader.Close();
                    return author;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int authorId)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTempAuthor, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((authorId) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathAuthor);
            File.Move(fileTempAuthor, filePathAuthor);
        }
        public static void Update(Author author)
        {
            StreamReader sReader = new StreamReader(filePathAuthor);
            StreamWriter sWriter = new StreamWriter(fileTempAuthor, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Convert.ToInt32(fields[0]) != (author.AuthorID)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2]);
                }

                line = sReader.ReadLine();// Attention : read the next line        
            }
            sWriter.WriteLine(author.AuthorID + "|" + author.FirstName + "|"
            + author.LastName);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePathAuthor);
            File.Move(fileTempAuthor, filePathAuthor);
        }
    }
}