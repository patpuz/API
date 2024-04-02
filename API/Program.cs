using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
[assembly:
InternalsVisibleTo("TestProject"), InternalsVisibleTo("GUI")]

namespace API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            Converter converter = new Converter();
            await converter.Run();

            Console.WriteLine("Do you want to retrieve and sort currencies from the database? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Select sorting option:");
                Console.WriteLine("1. By Name");
                Console.WriteLine("2. By Date");
                Console.WriteLine("3. By Value");
                int option = int.Parse(Console.ReadLine());

                List<Currency> sortedCurrencies = new List<Currency>();
                using (var db = new Currencies())
                {
                    switch (option)
                    {
                        case 1:
                            sortedCurrencies = db.GetSortedCurrenciesByName();
                            break;
                        case 2:
                            sortedCurrencies = db.GetSortedCurrenciesByDate();
                            break;
                        case 3:
                            sortedCurrencies = db.GetSortedCurrenciesByValue();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Showing all currencies");
                            db.ShowAllCurrencies();
                            break;
                    }

                    foreach (var currency in sortedCurrencies)
                    {
                        Console.WriteLine(currency);
                    }
                }
            }

            Console.WriteLine("Do you want to show all currencies from the database? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                using (var db = new Currencies())
                {
                    db.ShowAllCurrencies();
                }
            }
        }
    }
}
