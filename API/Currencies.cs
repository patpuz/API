using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Update;
using System.Runtime.CompilerServices;
using API;
[assembly:
InternalsVisibleTo("TestProject"), InternalsVisibleTo("GUI")]

namespace API
{
    internal class Currencies : DbContext
    {
        public DbSet<Currency> Kantor { get; set; }
        public Currencies()
        {
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite(@"Data Source=database.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasKey(c => c.Id);
        }

        public void ShowAllCurrencies()
        {
            var currencies = Kantor.ToList();
            foreach (var currency in currencies)
            {
                Console.WriteLine(currency);
            }
        }

        public List<Currency> GetSortedCurrenciesByName()
        {
            return Kantor.OrderBy(c => c.Name).ToList();
        }

        public List<Currency> GetSortedCurrenciesByDate()
        {
            return Kantor.OrderBy(c => c.Date).ToList();
        }

        public List<Currency> GetSortedCurrenciesByValue()
        {
            return Kantor.OrderBy(c => c.ExchangeRate).ToList();
        }
    }
}
