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

        public Currency(string name, int exchangeRate, bool isDefault = false)
        {
            this.Name = name;
            this.ExchangeRate = exchangeRate;
            this.IsDefault = isDefault;
        }
    }
}
