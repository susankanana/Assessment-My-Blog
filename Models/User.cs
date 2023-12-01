using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string username { get; set; } = string.Empty;

        public static implicit operator User(int v)
        {
            throw new NotImplementedException();
        }
    }
}
