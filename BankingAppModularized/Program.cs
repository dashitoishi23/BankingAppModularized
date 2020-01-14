using System;
using BankingApplicationModularized.Models;
using BankingApplicationModularized.Services;
namespace BankingAppModularized
{
    class Program
    {
        Manager Manager;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this banking app");
            Console.WriteLine("1. Continue as an existing bank ");
            Console.WriteLine("2. Continue as a new bank");
            int UserInput = Convert.ToInt32(Console.ReadLine());
            switch (UserInput)
            {
                case 1:

                    break;
            }
        }

    }
}
