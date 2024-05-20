using Data.DataContext;
using Microsoft.AspNetCore.Identity;
using TestApp.Models;

namespace TestApp.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext db, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User { UserName = "Test", Email = "Test@gmail.com" },
                    new User { UserName = "Test2", Email = "Test2@gmail.com" },
                    new User { UserName = "Test3", Email = "Test3@gmail.com" },

                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa!sswoord123");
                }
                if (!db.Posts.Any())
                {
                    var posts = new List<Post>
                    {
                        new Post
                        {
                            User=users[0],
                            Text = "Hello sadsadsadasdasdasdsa",
                            Date = DateTime.Now,
                            Title = "Post 1",
                            Category = Models.Enums.Category.Science,
                            Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"
                            



                        },
                        new Post
                        {
							User=users[1],

							Text = "Hello sadsadsadasdasdasdsa",
                            Date = DateTime.Now,
                            Title = "Post 1",
                            Category = Models.Enums.Category.Business,

                            Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"


                        },
                        new Post
                        {
							User=users[2],

							Text = "Hello sadsadsadasdasdasdsa",
                            Date = DateTime.Now,
                            Title = "Post 1",
                            Category = Models.Enums.Category.Politics,
                            Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"


                        },

                    };
                    await db.Posts.AddRangeAsync(posts);
                    await db.SaveChangesAsync();
                }
            }

        }
    }
}
