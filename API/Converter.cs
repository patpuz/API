using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("GUI")]
namespace API
{
    internal class Converter
    {
        private readonly HttpClient client = new HttpClient();
        private string ApiKey = "8eee30d3767845128f2af65ff2e78ade";
        private string BaseCurrency = "USD";

        public async Task Run()
        {
            Console.WriteLine("Enter the date in the format YYYY-MM-DD:");
            string date = Console.ReadLine();



            Console.WriteLine("Enter the currency:");
            string currency = Console.ReadLine().ToUpper();



            Currency currencyInfo = await GetCurrencyInfo(date, currency);


                Console.WriteLine(currencyInfo);
                await SaveCurrencyToDatabase(currencyInfo);


        }


        public async Task<Currency> GetCurrencyInfo(string date, string currency)
        {
            string call = $"https://openexchangerates.org/api/historical/{date}.json?app_id={ApiKey}&base={BaseCurrency}";
            string response = await client.GetStringAsync(call);

            ExchangeRatesData exchangeRatesData = JsonConvert.DeserializeObject<ExchangeRatesData>(response);

            if (exchangeRatesData.Rates.ContainsKey(currency))
            {
                double exchangeRate = exchangeRatesData.Rates[currency];
                return new Currency(currency, exchangeRate, date);
            }
            else
            {
                return null;
            }
        }

        private async Task SaveCurrencyToDatabase(Currency currency)
        {
            using (var db = new Currencies())
            {
                db.Kantor.Add(currency);
                await db.SaveChangesAsync();
            }
        }
    }

}

