using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Entities
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Department() { }
        public Department(int id, string name, Company company)
        {
            Id = id;
            Name = name;
            Company = company;
        }
    }
}
