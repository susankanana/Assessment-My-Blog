using MyBlog.Controls;
using MyBlog.Models;
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
        public UserServices userServices = new UserServices();
        public PostServices postServices = new PostServices();
        public CommentServices commentServices = new CommentServices();

        public async Task ShowAllUsers()
        {
            Console.WriteLine("===== Here are the users in the blog =====");
            var _users = await userServices.GetAllUsers();
            Console.WriteLine("User ID and User name");
            foreach ( var userr in _users)
            {
                Console.WriteLine($"ID: {userr.Id} \t Name: {userr.username}");
            }

            // await startPage.startMenu();

            Console.WriteLine("===== Enter userId of user whose posts you would like to view =====");
            string _id = Console.ReadLine();
            int id = int.Parse(_id);

            User user = _users.Find(u => u.Id == id);
            if (user != null)
            {

                Console.WriteLine($"User {user.username} has the following posts ");

                var posts = await ShowPosts(id);


                Console.WriteLine("===== Enter id of post whose comment you would like to view =====");
                var identered = Console.ReadLine();
                var ifPost = int.TryParse(identered, out int intPost);
                var _posts = await postServices.GetAllPosts();
                Post _post = _posts.Find(t => t.Id == intPost);
                if (_post != null)
                {

                    Console.WriteLine($"User {_post.Id} has the following comments ");
                    var comments = await ShowComments(intPost);


                }
            }
            else
            {
                Console.WriteLine("User not found in database.");
            }

        }
        public async Task<List<Post>> ShowPosts(int id)
        {
            var posts = await postServices.GetAllPosts();
            var _posts = posts.FindAll(i => i.userId == id);

            foreach (var post in _posts)
            {
                Console.WriteLine($"{post.Id} \t {post.Title}");
            }
            

            return posts;
        }

        public async Task<List<Comment>> ShowComments(int intPost)
        {
            var comments = await commentServices.GetAllComments();
            var _comments = comments.FindAll(i => i.postId == intPost);
            foreach(var comment in _comments)
            {
                Console.WriteLine($"{comment.Id} \t {comment.Name}");
            }

            return comments;
        }

    }
}