using System.Collections.Generic;

namespace threadslite.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Follow> Followers { get; set; } = new List<Follow>();
        public List<Follow> Following { get; set; } = new List<Follow>();
    }
}
