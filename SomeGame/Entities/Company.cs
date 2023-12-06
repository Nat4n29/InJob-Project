using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Entities
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

        public Company() { }
        public Company(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}
