using System;

namespace BankTest
{
    public class User
    {
        string name;
        List<Account> accounts = new List<Account>();

        public User()
        {
            Console.WriteLine("Enter your name");
            name = Console.ReadLine();

            Console.WriteLine("What should your first account be called?");
            accounts.Add(new Account(Console.ReadLine()));
        }
        public void Interacct()
        {
            Console.WriteLine("What would you like to do? (Use the corresponding number)");
            Console.WriteLine("1: Add an account");
            Console.WriteLine("2: Remove an account");
            Console.WriteLine("3: Deposit to an account");
            Console.WriteLine("4: Withdraw from an account");
            Console.WriteLine("5: Check balance of an account");
            Console.WriteLine("6: Rename an account");
            Console.WriteLine("7: Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddAccount();
                    break;
                case "2":
                    RemoveAccount();
                    break;
                case "3":
                    Deposit();
                    break;
                case "4":
                    Withdraw();
                    break;
                case "5":
                    ShowBalance();
                    break;
                case "6":
                    RenameAccount();
                    break;
                case "7":
                    Bank.Logout();
                    break;
                default:
                    Console.WriteLine("That was not a valid choice");
                    break;
            }
        }
        public string GetName()
        {
            return name;
        }

        public void AddAccount()
        {
            Console.WriteLine("What should this account be called?");
            accounts.Add(new Account(Console.ReadLine()));

        }
        public void RemoveAccount()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    Console.WriteLine("Account " + accounts[useAccount].GetAccountName() + " is removed.");
                    accounts.RemoveAt(useAccount);
                }
                else
                {
                    Console.WriteLine("Invalid input no account was removed.");
                }
            }
        }
        public void Deposit()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    Console.WriteLine("How much would you like to deposit?");
                    int amount = IntMaker(Console.ReadLine());
                    if (amount != -1)
                    {
                        accounts[useAccount].Deposit(amount);
                        Console.WriteLine("Deposit of " + amount + " to " + accounts[useAccount].GetAccountName() + " successful.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input no deposit made.");
                    }
                }
            }
        }

        public void Withdraw()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    Console.WriteLine("How much would you like to withdraw?");
                    int amount = IntMaker(Console.ReadLine());
                    if (amount != -1)
                    {
                        if (accounts[useAccount].GetBalance() >= amount)
                        {
                            accounts[useAccount].Withdraw(amount);
                            Console.WriteLine("Withdraw of " + amount + " from " + accounts[useAccount].GetAccountName() + " successful.");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input no withdraw made.");
                    }
                }
            }
        }

        public void ShowBalance()
        {
            int useAccount = WichAccount();
            if (useAccount != -1)
            {
                Console.WriteLine("Balance of " + accounts[useAccount].GetAccountName() + " is " + accounts[useAccount].GetBalance());
            }
        }
        public void RenameAccount()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    string oldName = accounts[useAccount].GetAccountName();
                    Console.WriteLine("What should the new name be?");
                    accounts[useAccount].SetAccountName(Console.ReadLine());
                    Console.WriteLine($"Account {oldName} is renamed to {accounts[useAccount].GetAccountName()}");
                }
            }
        }
        private bool HasAccounts()
        {
            if (accounts.Count != 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You have no accounts. Make one to strart managing it.");
                return false;
            }
        }
        private int WichAccount()
        {
            Console.WriteLine("Which account would you like to use?");

            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine(i + ": " + accounts[i].GetAccountName());
            }
            int useAccount = IntMaker(Console.ReadLine());
            if (useAccount < accounts.Count)
            {
                return useAccount;
            }
            else
            {
                Console.WriteLine($"Invalid input, No account with number {useAccount}.");
                return -1;
            }
        }
        public int IntMaker(string input)
        {
            bool correct;
            int output;
            correct = int.TryParse(input, out output);
            if (correct)
            {
                return output;
            }
            Console.WriteLine("That Was Not A valid Number");
            return -1;
        }
    }
}