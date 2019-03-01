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
    public static class EmployeeDA
    {
        private static string filePath = Application.StartupPath + @"\Employee.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Employees employee)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(Convert.ToInt32(employee.EmployeeId) + "|" + employee.FirstName + "|" + employee.LastName
                + "|" + employee.JobTitle + "|" + employee.HomePhone + "|" + employee.Email + "|" + employee.Status);
            sWriter.Close();
            MessageBox.Show("Employee Data has been saved.");
        }
        public static void ListEmployee(ListView listEmp)
        {
            StreamReader sReader = new StreamReader(filePath);
            listEmp.Items.Clear();
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
                listEmp.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static List<Employees> ListEmployee()
        {
            List<Employees> listEmp = new List<Employees>();
            StreamReader sReader = new StreamReader(filePath);

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                Employees employee = new Employees();
                employee.EmployeeId = Convert.ToInt32(fields[0]);
                employee.FirstName = fields[1];
                employee.LastName = fields[2];
                employee.JobTitle = fields[3];
                employee.HomePhone = fields[4];
                employee.Email = fields[5];
                employee.Status = fields[6];
                listEmp.Add(employee);
                line = sReader.ReadLine();
            }
            sReader.Close();
            return listEmp;
        }
        public static Employees Search(int employeeId)
        {
            Employees employee = new Employees();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if (employeeId == Convert.ToInt32(fields[0]))
                {
                    employee.EmployeeId = Convert.ToInt32(fields[0]);
                    employee.FirstName = fields[1];
                    employee.LastName = fields[2];
                    employee.JobTitle = fields[3];
                    employee.HomePhone = fields[4];
                    employee.Email = fields[5];
                    employee.Status = fields[6];
                    sReader.Close();
                    return employee;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int employeeId)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((employeeId) != (Convert.ToInt32(fields[0])))
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
        public static void Update(Employees employee)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                if (Convert.ToInt32(fields[0]) != (employee.EmployeeId))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4]
                     + "|" + fields[5] + "|" + fields[6]);
                }

                        line = sReader.ReadLine();      
            }
            sWriter.WriteLine(employee.EmployeeId + "|" + employee.FirstName + "|" + employee.LastName
                + "|" + employee.JobTitle + "|" + employee.HomePhone + "|" + employee.Email + "|" + employee.Status);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}