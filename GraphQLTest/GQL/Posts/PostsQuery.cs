using GraphQLTest.Context;
using GraphQLTest.Shared.Models;

using HotChocolate.Internal;

namespace GraphQLTest.GQL.Posts;

[ExtendObjectType(HotChocolate.Language.OperationType.Query)]
public class PostsQuery 
{
	//[UsePaging]
	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<Post> GetPosts(AppDbContext dbContext) => dbContext.Posts;

	[GraphQLName("postById")]
	public Post? GetPostById(Guid id, AppDbContext dbContext)
	{
		return dbContext.Posts.Find(id);
	}
}