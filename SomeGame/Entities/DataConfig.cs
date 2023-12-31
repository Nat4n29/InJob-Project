﻿using System;
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

        public void DeleteCompany(int idComp)
        {
            Employees.Remove(Employees.Where(X => X.Company.Id == idComp).FirstOrDefault());

            Departments.Remove(Departments.Where(X => X.Company.Id == idComp).FirstOrDefault());

            Companies.Remove(Companies.Where(x => x.Id == idComp).FirstOrDefault());
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

        public void DeleteDepartment(int idDep)
        {
            Employees.Remove(Employees.Where(x => x.Department.Id == idDep).FirstOrDefault());

            Departments.Remove(Departments.Where(x => x.Id == idDep).FirstOrDefault());
        }

        public void AttDepartment(string name, int id, string comName)
        {
            Company company = Companies.Where(x => x.Name == comName).FirstOrDefault();

            Departments.Add(new Department(id, name, company));
        }

        public void AddEmployee(string name, double salary, int idComp, int idDep)
        {
            int index = Employees.Count();

            Company company = Companies.Where(x => x.Id == idComp).FirstOrDefault();
            Department department = Departments.Where(x => x.Id == idDep).FirstOrDefault();

            Employees.Add(new Employee(index + 1, name, salary, department, company));
        }

        public void AttEmployee(int id, string name, double salary, string depName, string comName)
        {
            Company company = Companies.Where(x => x.Name == comName).FirstOrDefault();
            Department department = Departments.Where(x => x.Name == depName).FirstOrDefault();

            Employees.Add(new Employee(id, name, salary, department, company));
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
