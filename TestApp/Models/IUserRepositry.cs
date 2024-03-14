namespace TestApp.Models
{
    public interface IUserRepositry
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
		User GetUserByEmail(string email);

		void InsertUser(string email, string password);
        void DeleteUser(int id);
        void UpdateUser(User post);
        void Save();
    }
}
