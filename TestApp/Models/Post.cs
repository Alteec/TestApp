
using System.ComponentModel.DataAnnotations;
using TestApp.Models.Enums;

namespace TestApp.Models
{
    public class Post
    {
            [Key]
            public Guid Id { get; set; }

		    public string Title { get; set; }

		    public string Text { get; set; }
            public string? Photo { get; set; }
            public DateTime Date { get; set; }
            public User User { get; set; }
            public Category Category { get; set; }
            
	}
}
