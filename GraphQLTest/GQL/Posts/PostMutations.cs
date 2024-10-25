using GraphQLTest.Context;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.GQL.Posts;

[ExtendObjectType(HotChocolate.Language.OperationType.Mutation)]
public class PostMutations
{
	public async Task<Post> AddPost(AppDbContext appDbContext, Guid authorId, string title, string content)
	{
		Post post = new()
		{
			AuthorId = authorId,
			Content = content,
			Title = title
		};
		appDbContext.Posts.Add(post);
		await appDbContext.SaveChangesAsync();

		return post;
	}
}