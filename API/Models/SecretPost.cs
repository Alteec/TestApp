using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class SecretPost
	{
		[Key]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string? Photo { get; set; }
	}
}
