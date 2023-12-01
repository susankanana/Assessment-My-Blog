using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    internal class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public Post PostId { get; set; }
    }
}
