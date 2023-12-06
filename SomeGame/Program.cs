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

                while(num != 4)
                {
                    Console.WriteLine("Select one action below:");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("1 - Add");
                    Console.WriteLine("2 - Delete");
                    Console.WriteLine("3 - Search");
                    Console.WriteLine("4 - Close");
                    Console.WriteLine();

                    num = int.Parse(Console.ReadLine());

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

                        if (num == 1)
                        {
                            Console.Write("Company name:");
                            string name = Console.ReadLine();
                            config.AddCompany(name);
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
                        }
                    }
                }

                using (StreamReader sr = File.OpenText(DataConfig.PathCompany()))
                {

                    while (!sr.EndOfStream)
                    {
                        string[] lines = sr.ReadLine().Split('-');
                        foreach (string line in lines)
                        {
                            //config.AddCompany(line[1]);
                        }

                        Console.WriteLine(line);
                    }
                    sr.Close();
                }

                using (StreamWriter sw = new StreamWriter(DataConfig.PathCompany()))
                {
                    foreach(Company comp in config.Companies)
                    {
                        sw.WriteLine($"{comp.Id} - {comp.Name}");
                        sw.WriteLine();
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