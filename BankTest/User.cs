using System;
using System.Text.Json;

namespace BankTest
{
    public class User
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public User()
        {

        }

        public User(bool askForName = false)
        {
            if (askForName)
            {
                Console.WriteLine("Enter your name");
                Name = Console.ReadLine();

                Console.WriteLine("What should your account be called?");
                Accounts.Add(new Account(Console.ReadLine()));
            }
        }
        public void Interacct()
        {
            Console.WriteLine($"Welcome {Name}");
            Console.WriteLine("What would you like to do? (Use the corresponding number)");
            Console.WriteLine("1: Add an account");
            Console.WriteLine("2: Remove an account");
            Console.WriteLine("3: Deposit to an account");
            Console.WriteLine("4: Withdraw from an account");
            Console.WriteLine("5: Check balance of an account");
            Console.WriteLine("6: Rename an account");
            Console.WriteLine("7: Moove funds");
            Console.WriteLine("8: Exit");
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
                    MoveFunds();
                    break;
                case "8":
                    Bank.Logout();
                    break;
                default:
                    Console.WriteLine("That was not a valid choice");
                    break;
            }
        }
        public string GetName()
        {
            return Name;
        }

        public void AddAccount()
        {
            Console.WriteLine("What should this account be called?");
            Accounts.Add(new Account(Console.ReadLine()));

        }
        public void RemoveAccount()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    Console.WriteLine("Account " + Accounts[useAccount].GetAccountName() + " is removed.");
                    Accounts.RemoveAt(useAccount);
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
                        Accounts[useAccount].Deposit(amount);
                        Console.WriteLine("Deposit of " + amount + " to " + Accounts[useAccount].GetAccountName() + " successful.");
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
                        if (Accounts[useAccount].GetBalance() >= amount)
                        {
                            Accounts[useAccount].Withdraw(amount);
                            Console.WriteLine("Withdraw of " + amount + " from " + Accounts[useAccount].GetAccountName() + " successful.");
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
                Console.WriteLine("Balance of " + Accounts[useAccount].GetAccountName() + " is " + Accounts[useAccount].GetBalance());
            }
        }
        public void RenameAccount()
        {
            if (HasAccounts())
            {
                int useAccount = WichAccount();
                if (useAccount != -1)
                {
                    string oldName = Accounts[useAccount].GetAccountName();
                    Console.WriteLine("What should the new name be?");
                    Accounts[useAccount].SetAccountName(Console.ReadLine());
                    Console.WriteLine($"Account {oldName} is renamed to {Accounts[useAccount].GetAccountName()}");
                }
            }
        }
        public void MoveFunds()
        {
            if (HasAccounts())
            {
                Console.WriteLine("Which account would you like to move funds from?");
                for (int i = 0; i < Accounts.Count; i++)
                {
                    Console.WriteLine(i + ": " + Accounts[i].GetAccountName());
                }
                int fromAccount = IntMaker(Console.ReadLine());
                if (fromAccount != -1)
                {
                    Console.WriteLine("Which account would you like to move funds to?");
                    for (int i = 0; i < Accounts.Count; i++)
                    {
                        Console.WriteLine(i + ": " + Accounts[i].GetAccountName());
                    }
                    int toAccount = IntMaker(Console.ReadLine());
                    if (toAccount != -1 && fromAccount != toAccount)
                    {

                        Console.WriteLine("How much would you like to move?");
                        int amount = IntMaker(Console.ReadLine());
                        if (amount != -1)
                        {
                            if (Accounts[fromAccount].GetBalance() >= amount)
                            {
                                Accounts[fromAccount].Withdraw(amount);
                                Accounts[toAccount].Deposit(amount);
                                Console.WriteLine("Transfer of " + amount + " from " + Accounts[fromAccount].GetAccountName() + " to " + Accounts[toAccount].GetAccountName() + " is successful.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input no move made.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input no move made.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input no funds moved.");
                }


            }
        }

        private bool HasAccounts()
        {
            if (Accounts.Count != 0)
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

            for (int i = 0; i < Accounts.Count; i++)
            {
                Console.WriteLine(i + ": " + Accounts[i].GetAccountName());
            }
            int useAccount = IntMaker(Console.ReadLine());
            if (useAccount < Accounts.Count)
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