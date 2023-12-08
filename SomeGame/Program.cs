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
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}