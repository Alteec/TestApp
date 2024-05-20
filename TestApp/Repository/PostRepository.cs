using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Interfaces;
using TestApp.Models;
using TestApp.Models.Enums;

namespace TestApp.Repository
{
	public class PostRepository : IPostRepository
	{
		private readonly DataContext _db;
		public PostRepository(DataContext db) {
			_db = db;
		}
		public bool Add(Post post)
		{
			post.Date=DateTime.Now;
			_db.Posts.Add(post);
			return Save();
		}

		public bool Delete(Post post)
		{
			_db.Posts.Remove(post);
			return Save();

			 
		}

		public async Task<IEnumerable<Post>> GetByCategory(Category name)
		{
			return await _db.Posts.Include(u => u.User).Where(p => p.Category==name).ToListAsync();
		}


		public async Task<Post> GetById(Guid id)
		{
			return await _db.Posts.Include(u=>u.User).FirstOrDefaultAsync(p=>p.Id==id);
		}

		public async Task<Post> GetByIdNoTracking(Guid id)
		{
			return await _db.Posts.Include(u => u.User).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
		}


		public async Task<IEnumerable<Post>> GetList()
		{

			var list= await _db.Posts.Include(u => u.User).ToListAsync();
			list.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
			list.Reverse();
			return list;

		}

		public bool Save()
		{
			return _db.SaveChanges() > 0;
		}

		public bool Update(Post post)
		{
			_db.Posts.Update(post);
			return Save();
		}
	}
}
