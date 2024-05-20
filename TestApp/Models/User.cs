
using Microsoft.AspNetCore.Identity;

namespace TestApp.Models
{
    public class User:IdentityUser
    {
        public ICollection<Post> Posts { get; set; }
    }
}