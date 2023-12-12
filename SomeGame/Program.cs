using SomeGame.Entities;
using System;
using System.Globalization;

namespace SomeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataConfig config = new DataConfig();

                int num = 0;

                //Update Companies.txt
                using (StreamReader sr = File.OpenText(DataConfig.PathCompany()))
                {

                    while (!sr.EndOfStream)
                    {
                            string[] var = sr.ReadLine().Split('-');
                            int id = int.Parse(var[0]);
                            string name = var[1];

                            config.AttCompany(name, id);
                    }
                    sr.Close();
                }

                //Update Department.txt
                using (StreamReader sr = File.OpenText(DataConfig.PathDepartment()))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] var = sr.ReadLine().Split('-');
                        int id = int.Parse(var[0]);
                        string name = var[1];
                        string compName = var[2];

                        config.AttDepartment(name, id, compName);
                    }
                    sr.Close();
                }

                //Update Employee.txt
                using (StreamReader sr = File.OpenText(DataConfig.PathEmployee()))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] var = sr.ReadLine().Split('-');
                        int id = int.Parse(var[0]);
                        string name = var[1];
                        double salary = double.Parse(var[2]);
                        string depName = var[3];
                        string compName = var[4];

                        config.AttEmployee(id, name, salary, depName, compName);
                    }
                    sr.Close();
                }

                while (num != 4)
                {
                    //Menu
                    if(num == 0)
                    {
                        DataConfig.Menu();

                        num = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }

                    //Add
                    if (num == 1)
                    {
                        DataConfig.AddShowDeleteMenu();

                        num = int.Parse(Console.ReadLine());
                        Console.Clear();
                        
                        //Add Company
                        if (num == 1)
                        {
                            Console.Write("Company name:");
                            string name = Console.ReadLine();
                            config.AddCompany(name);
                            Console.Clear();
                        }

                        //Add Department
                        if (num == 2)
                        {
                            Console.Write("Department name:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Select a Company:");
                            Console.WriteLine("------------------------");
                            foreach (Company comp in config.Companies)
                            {
                                Console.WriteLine(comp.Id + "-" + comp.Name);
                            }
                            Console.WriteLine();

                            int id = int.Parse(Console.ReadLine());

                            config.AddDepartment(name, id);
                            Console.Clear();
                            num = 0;
                        }

                        //Add Employee
                        if(num == 3)
                        {
                            Console.Write("Employee name: ");
                            string name = Console.ReadLine();

                            Console.Write("Employee salary: ");
                            double salary = double.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("Select a Company:");
                            Console.WriteLine("------------------------");
                            foreach (Company comp in config.Companies)
                            {
                                Console.WriteLine(comp.Id + "-" + comp.Name);
                            }
                            Console.WriteLine();

                            int idComp = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("Select a Department:");
                            Console.WriteLine("------------------------");
                            foreach(Department department in config.Departments)
                            {
                                Console.WriteLine(department.Id + "-" + department.Name);
                            }
                            Console.WriteLine();

                            int idDep = int.Parse(Console.ReadLine());

                            config.AddEmployee(name, salary, idComp, idDep);
                            Console.Clear();
                            num = 0;
                        }
                    }
                    //Delete
                    
                    //2

                    //Show List
                    if(num == 3)
                    {
                        DataConfig.AddShowDeleteMenu();

                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();

                        //Show Company List
                        if (num == 1)
                        {
                            foreach(Company comp in config.Companies)
                            {
                                Console.WriteLine($"{comp.Id}-{comp.Name}");
                            }

                            Console.ReadLine();
                            num = 0;
                            Console.Clear();
                        }

                        //Show Department List
                        if( num == 2)
                        {
                            Console.WriteLine("Select a Company:");
                            Console.WriteLine("------------------------");
                            foreach (Company comp in config.Companies)
                            {
                                Console.WriteLine(comp.Id + "-" + comp.Name);
                            }
                            Console.WriteLine();

                            int id = int.Parse(Console.ReadLine());
                            Console.Clear();

                            foreach(Department dep in config.Departments.Where(x => x.Company.Id == id))
                            {
                                Console.WriteLine($"{dep.Id}-{dep.Name}");
                            }

                            Console.ReadLine();
                            num = 0;
                            Console.Clear();
                        }

                        //Show Employee List
                        if(num == 3)
                        {
                            Console.WriteLine("Select a option:");
                            Console.WriteLine("------------------------");
                            Console.WriteLine();
                            Console.WriteLine("1 - All Employees");
                            Console.WriteLine("2 - All Employees of a Company");
                            Console.WriteLine("3 - All Employees of a Department");
                            Console.WriteLine();

                            int opt = int.Parse(Console.ReadLine());
                            Console.Clear();

                            //All Employees
                            if(opt == 1)
                            {
                                foreach(Employee emp in config.Employees)
                                {
                                    Console.WriteLine(emp.Id + "-" + emp.Name);
                                }
                                Console.ReadLine();
                                num = 0;
                                Console.Clear();
                            }

                            //All Employees of a Company
                            if(opt == 2)
                            {
                                Console.WriteLine("Select a Company:");
                                Console.WriteLine("------------------------");
                                foreach (Company comp in config.Companies)
                                {
                                    Console.WriteLine(comp.Id + "-" + comp.Name);
                                }
                                Console.WriteLine();

                                int id = int.Parse(Console.ReadLine());
                                Console.Clear();

                                foreach(Employee emp in config.Employees.Where(x => x.Company.Id == id))
                                {
                                    Console.WriteLine(emp.Id + "-" + emp.Name);
                                }

                                Console.ReadLine();
                                num = 0;
                                Console.Clear();
                            }

                            //All Employees of a Department
                            if(opt == 3)
                            {
                                Console.WriteLine("Select a Company:");
                                Console.WriteLine("------------------------");
                                foreach (Company comp in config.Companies)
                                {
                                    Console.WriteLine(comp.Id + "-" + comp.Name);
                                }
                                Console.WriteLine();

                                int idComp = int.Parse(Console.ReadLine());
                                Console.Clear();

                                Console.WriteLine("Select a Department:");
                                Console.WriteLine("------------------------");
                                foreach(Department department in config.Departments.Where(x => x.Company.Id == idComp))
                                {
                                    Console.WriteLine(department.Id + "-" + department.Name);
                                }
                                Console.WriteLine();

                                int idDep = int.Parse(Console.ReadLine());
                                Console.Clear();

                                foreach(Employee emp in config.Employees.Where(x => x.Company.Id == idComp && x.Department.Id == idDep))
                                {
                                    Console.WriteLine(emp.Id + "-" + emp.Name);
                                }
                                Console.WriteLine();

                                Console.ReadLine();
                                num = 0;
                                Console.Clear();
                            }
                        }
                    }
                }

                using (StreamWriter sw = new StreamWriter(DataConfig.PathCompany()))
                {
                    foreach(Company comp in config.Companies)
                    {
                        sw.WriteLine($"{comp.Id}-{comp.Name}");
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(DataConfig.PathDepartment()))
                {
                    foreach(Department dep in config.Departments)
                    {
                        sw.WriteLine($"{dep.Id}-{dep.Name}-{dep.Company.Name}");
                    }
                    sw.Close();
                }

                using (StreamWriter sw = new StreamWriter(DataConfig.PathEmployee()))
                {
                    foreach(Employee emp in config.Employees)
                    {
                        sw.WriteLine($"{emp.Id}-{emp.Name}-{emp.Salary.ToString("F2", CultureInfo.InvariantCulture)}-{emp.Department.Name}-{emp.Company.Name}");
                    }
                    sw.Close();
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}