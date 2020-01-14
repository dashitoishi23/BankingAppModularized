using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public int ExchangeRate { get; set; }
        public bool IsDefault { get; set; }

        public Currency(string Name, int ExchangeRate, bool IsDefault)
        {
            this.Name = Name;
            this.ExchangeRate = ExchangeRate;
            this.IsDefault = IsDefault;
        }
    }
}
