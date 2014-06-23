using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeanCodeRefactor.BusinessObjects;

namespace LeanCodeRefactor
{
    public static class Runner
    {
        private static readonly Checkout _checkout = new Checkout();

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fresco Checkout");
            Console.WriteLine("Enter items individually or comma seperated");
            Console.Write(" => ");
            var input = Console.ReadLine();

            while(!string.IsNullOrEmpty(input))
            {
                Console.WriteLine(_checkout.Scan(input));
                Console.Write(" => ");
                input = Console.ReadLine();
            } 
        }
    }
}
