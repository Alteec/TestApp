namespace TestApp.Models
{
    public interface IPostRepositry
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int id);
        void InsertPost(Post post);
        void DeletePost(int id);
        void UpdatePost(Post post);
        void Save();
    }
}
