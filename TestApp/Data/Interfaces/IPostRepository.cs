using TestApp.Models;
using TestApp.Models.Enums;

namespace TestApp.Data.Interfaces
{
	public interface IPostRepository
	{
		Task<IEnumerable<Post>> GetList();
		Task<Post> GetById(Guid id);
		Task<Post> GetByIdNoTracking(Guid id);

		Task<IEnumerable<Post>> GetByCategory(Category category);
		bool Add(Post post);
		bool Update(Post post);
		bool Delete(Post post);
		bool Save();

	}
}
