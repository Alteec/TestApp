using System.ComponentModel.DataAnnotations;

namespace TestApp.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]

		public string EmailAddress { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
