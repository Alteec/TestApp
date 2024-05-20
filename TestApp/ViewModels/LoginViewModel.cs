using System.ComponentModel.DataAnnotations;

namespace TestApp.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]

		public string EmailAddress { get; set;}

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
