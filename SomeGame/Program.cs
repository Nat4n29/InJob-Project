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

                //string[] lines = File.ReadAllLines(DataConfig.PathCompany());
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

                while (num != 4)
                {
                    if(num == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Select one action below:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1 - Add");
                        Console.WriteLine("2 - Delete");
                        Console.WriteLine("3 - Show List");
                        Console.WriteLine("4 - Close");
                        Console.WriteLine();

                        num = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }

                    if (num == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Select one action below:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1 - Company");
                        Console.WriteLine("2 - Department");
                        Console.WriteLine("3 - Employee");
                        Console.WriteLine();

                        num = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (num == 1)
                        {
                            Console.Write("Company name:");
                            string name = Console.ReadLine();
                            config.AddCompany(name);
                            Console.Clear();
                        }
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
                        }
                    }
                    //2
                    if(num == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Select one action below:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("1 - Company");
                        Console.WriteLine("2 - Department");
                        Console.WriteLine("3 - Employee");
                        Console.WriteLine();

                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();

                        if (num == 1)
                        {
                            foreach(Company comp in config.Companies)
                            {
                                Console.WriteLine($"{comp.Id}-{comp.Name}");
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
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}