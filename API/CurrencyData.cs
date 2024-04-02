using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class ExchangeRatesData
    {
        public string Base { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
