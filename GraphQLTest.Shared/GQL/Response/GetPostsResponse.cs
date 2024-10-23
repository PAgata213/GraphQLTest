using GraphQLTest.Shared.Models;

namespace GraphQLTest.Shared.GQL.Response;
public record GetPostsResponse
{
	public IList<Post> Posts { get; set; } = [];
}
