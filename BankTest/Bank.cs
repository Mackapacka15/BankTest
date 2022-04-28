using System;
using System.Text.Json;

namespace BankTest
{
    public static class Bank
    {
        static List<User> users = new List<User>();
        static User currentUser;

        static Bank()
        {
            Load();
        }

        static public bool Update()
        {
            if (currentUser != null)
            {
                currentUser.Interacct();
            }
            else
            {
                Console.WriteLine("What would you like to do? (Use the corresponding number)");
                Console.WriteLine("1: Create a new user");
                Console.WriteLine("2: Manage existing user");
                Console.WriteLine("3: Exit bank");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ManageUser();
                        break;
                    case "3":
                        Save();
                        return false;
                    default:
                        Console.WriteLine("That was not a valid choice");
                        break;
                }
            }
            Save();
            return true;
        }

        static public void CreateUser()
        {
            User u = new User(true);
            users.Add(u);
            currentUser = u;
        }
        static public void Logout()
        {
            currentUser = null;
        }

        static public void ManageUser()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("There are no users to manage");
            }
            else
            {
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(i + ": " + users[i].GetName());
                }

                Console.WriteLine("Which user would you like to manage? (Use the corresponding number)");
                string choice = Console.ReadLine();
                int index = IntMaker(choice);
                if (index != -1 && index < users.Count)
                {
                    currentUser = users[index];
                }
                else
                {
                    Console.WriteLine("That was not a valid choice");
                }
            }
        }
        static public void Load()
        {
            string json = System.IO.File.ReadAllText(@"Users.json");
            if (!string.IsNullOrEmpty(json.Trim()))
            {
                users = JsonSerializer.Deserialize<List<User>>(json);
            }
        }
        static public void Save()
        {
            string jsonstring = JsonSerializer.Serialize<List<User>>(users);
            System.IO.File.WriteAllText(@"Users.json", jsonstring);
        }

        static public int IntMaker(string input)
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