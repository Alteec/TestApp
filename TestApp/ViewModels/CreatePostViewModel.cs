using System.ComponentModel.DataAnnotations;
using TestApp.Models.Enums;

namespace TestApp.ViewModels
{
	public class CreatePostViewModel

	{
		public Guid Id { get; set; }

		[StringLength(20, MinimumLength = 8)]
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }


		[StringLength(1200, MinimumLength = 10)]
		[Required(ErrorMessage = "Text is required")]
		public string Text { get; set; }
		public string? Photo { get; set; }
		public Category Category { get; set; }
	}
}
