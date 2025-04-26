using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Controls
{
   public class StartPage
    {
        UserManager userManager = new UserManager();

        public async Task startMenu()
        {
            Console.WriteLine("1. Welcome Page");
            Console.WriteLine("2. View current users");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            var output = int.TryParse(input, out int choice);
            await switchUser(choice);
        }

        public async Task switchUser(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Welcome to my blog.Our data is opensource. You may view" +
                        "our current users and their posts.");
                    break;
                case 2:
                    await userManager.ShowAllUsers();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
