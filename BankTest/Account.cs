using System;

namespace BankTest
{
    public class Account
    {
        string accountName;
        int balance = 0;

        public Account(string accountNamein)
        {
            if (string.IsNullOrWhiteSpace(accountNamein))
            {
                accountName = "Unnamed Account";
            }
            else
            {
                accountName = accountNamein;
            }
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }
        public void Withdraw(int amount)
        {
            balance -= amount;
        }
        public int GetBalance()
        {
            return balance;
        }
        public string GetAccountName()
        {
            return accountName;
        }
        public void SetAccountName(string newName)
        {
            accountName = newName;
        }
    }
}