using System;
using System.Collections.Generic;

namespace BankingApplicationModularized.Models
{
    public class Manager
    {
        public string userID { get; set; }
        public string password { get; set; }
        public List<Bank> Banks = new List<Bank>();
    }
}
