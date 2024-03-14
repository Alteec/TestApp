using Microsoft.VisualBasic;

namespace TestApp.Models
{
    public class Post
    {
            public int Id { get; set; }
            public int UserId {  get; set; }
            public string? Title { get; set; }
            public string? Text { get; set; }
            public string? Photo { get; set; }
            public DateTime Created { get; set; }

            public string Date => Created.ToString("dd/MM/yyyy");

	}
}
