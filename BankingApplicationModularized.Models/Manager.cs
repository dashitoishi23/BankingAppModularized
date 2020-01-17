using System;
using System.Collections.Generic;

namespace BankingApplicationModularized.Models
{
    public class Manager
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public List<Bank> Banks = new List<Bank>();
    }

}
