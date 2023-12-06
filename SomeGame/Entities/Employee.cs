using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public Company Company { get; set; }

        public Employee()
        {
        }
        public Employee(int id, string name, double salary, Department department, Company company)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Department = department;
            Company = company;
        }
    }
}
