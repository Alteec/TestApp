using API.Data;
using Microsoft.AspNetCore.Identity;
using API.Models;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext db)
        {

                if (!db.Posts.Any())
                {
                    var posts = new List<SecretPost>
                    {
                        new SecretPost
                        {
                            Text = "Secret 1",
                            Title = "Post 1",
                            Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"


                        },
												new SecretPost
						{
							Text = "Secret 2",
							Title = "Post 2",
							Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"


						},
																		new SecretPost
						{
							Text = "Secret 3",
							Title = "Secret 3",
							Photo = "https://www.nasa.gov/wp-content/uploads/2023/06/jwst-flickr-52259221868-30e1c78f0c-4k.jpg?w=2048"


						},

					};
                    await db.Posts.AddRangeAsync(posts);
                    await db.SaveChangesAsync();
                }
  

        }
    }
}
