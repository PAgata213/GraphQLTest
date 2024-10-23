using GraphQLTest.Context;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.GQL;

public class QueryProvider
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

	//[UsePaging]
	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<Comment> GetComments(AppDbContext dbContext) => dbContext.Comments;
}
