using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.IServices
{
    internal interface IComment
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> GetCommentByPostId(int id);
    }
}
