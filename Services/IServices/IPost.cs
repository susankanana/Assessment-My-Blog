using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.IServices
{
    internal interface IPost
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostByUserId(int id);
        
    }
}
