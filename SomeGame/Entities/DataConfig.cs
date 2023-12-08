using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Entities
{
    internal class DataConfig
    {
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public static string PathCompany()
        {
            return @"C:\Users\DELL\Documents\GitHub\InJob-Project\SomeGame\Data\Companies.txt";
        }

        public static string PathDepartment()
        {
            return @"C:\Users\DELL\Documents\GitHub\InJob-Project\SomeGame\Data\Departments.txt";
        }

        public static string PathEmployee()
        {
            return @"C:\Users\DELL\Documents\GitHub\InJob-Project\SomeGame\Data\Employees.txt";
        }

        public void AddCompany(string name)
        {
            int index = Companies.Count();

            Companies.Add(new Company(name, index + 1));
        }

        public void AttCompany(string name, int id)
        {
            Companies.Add(new Company(name, id));
        }

        public void AddDepartment(string name, int id)
        {
            int index = Departments.Count();

            Company company = Companies.Where(x => x.Id == id).FirstOrDefault();

            Departments.Add(new Department(index + 1, name, company));
        }

        public void AttDepartment(string name, int id, string comName)
        {
            Company company = Companies.Where(x => x.Name == name).FirstOrDefault();

            Departments.Add(new Department(id, name, company));
        }

        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Select one action below:");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            Console.WriteLine("3 - Show List");
            Console.WriteLine("4 - Close");
            Console.WriteLine();
        }

        public static void AddShowDeleteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select one action below:");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Company");
            Console.WriteLine("2 - Department");
            Console.WriteLine("3 - Employee");
            Console.WriteLine();
        }
    }
}
