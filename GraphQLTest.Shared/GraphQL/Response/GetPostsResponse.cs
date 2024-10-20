using GraphQLTest.Shared.Models;

namespace GraphQLTest.Shared.GraphQL.Response;
public record GetPostsResponse
{
	public IList<Post> Posts { get; set; } = [];
}
