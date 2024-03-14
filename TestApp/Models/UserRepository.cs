

using System.Collections.Generic;

namespace TestApp.Models
{
    public class UserRepository : IUserRepositry
    {
        List<User> _users = new List<User>();
        private static int _count = 0;
        public UserRepository()
        {
            _users.Add(new User { Id = _count++, Email = "test@gmail.com", Password = "test123" });
            _users.Add(new User { Id = _count++, Email = "test2@gmail.com", Password = "test123" });
            _users.Add(new User { Id = _count++, Email = "test3@gmail.com", Password = "test123" });
        }
		public User GetUserByEmail(string email)
        {
			return _users.FirstOrDefault(i => i.Email == email);
		}

		public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void InsertUser(string email, string password)
        {
            _users.Add(new User { Id = _count++, Email = email, Password = password });
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User post)
        {
            throw new NotImplementedException();
        }

	
	}

}
