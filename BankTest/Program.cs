using System;

namespace BankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool use = true;
            while (use)
            {
                use = Bank.Update();
            }
        }
    }
}

