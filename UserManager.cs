using MyBlog.Controls;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog
{
    internal class UserManager
    {
        public StartPage startPage = new StartPage();   
        public UserServices userServices = new UserServices();
        public PostServices postServices = new PostServices();
        public CommentServices commentServices = new CommentServices();

        public async Task ShowAllUsers()
        {
            Console.WriteLine("===== Here are the users in the blog =====");
            var _users = await userServices.GetAllUsers();
            Console.WriteLine(_users);

            await startPage.startMenu();
        }
    }
}
