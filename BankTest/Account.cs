using System;

namespace BankTest
{
    public class Account
    {
        public string AccountName { get; set; }
        public int Balance { get; set; } = 0;

        public Account()
        {

        }

        public Account(string accountNamein = "")
        {
            if (string.IsNullOrWhiteSpace(accountNamein))
            {
                AccountName = "Unnamed Account";
            }
            else
            {
                AccountName = accountNamein;
            }
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
        public int GetBalance()
        {
            return Balance;
        }
        public string GetAccountName()
        {
            return AccountName;
        }
        public void SetAccountName(string newName)
        {
            AccountName = newName;
        }
    }
}