using GraphQLTest.Shared.Models;

namespace GraphQLTest.Context;

public class SeedData
{
	public static async Task SeedDataToDBAsync(AppDbContext dbContext)
	{
		var rng = new Random(345985);
		List<Post> posts = Enumerable.Range(1, 10)
		.Select(p => new Post
		{
			AuthorId = Guid.NewGuid(),
			Content = $"Test Content {p}",
			Title = $"Test title {p}",
			Comments = Enumerable.Range(1, (int)rng.NextInt64(1, 20)).Select(c => new Comment
			{
				Content = $"Test Comment Content {c}",
				AuthorId = Guid.NewGuid()
			}).ToList()
		}).ToList();

		await dbContext.Posts.AddRangeAsync(posts);
		await dbContext.SaveChangesAsync();
	}
}
