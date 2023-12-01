using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public static implicit operator Post(int v)
        {
            throw new NotImplementedException();
        }
    }
}
