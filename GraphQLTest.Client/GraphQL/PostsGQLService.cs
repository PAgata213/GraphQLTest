using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Query.Builder;

using GraphQLTest.Shared.GraphQL.Response;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.Client.GraphQL;

public class PostsGQLService(IGraphQLClient _graphQLClient) : IPostsGQLService
{
	private readonly IGraphQLClient _graphQLClient = _graphQLClient;

	public async Task<IList<Post>> GetPostsAsync(IQuery<Post>? query = null)
	{
		query ??= GraphQLTest.Shared.GraphQL.Query.GetPosts;
		var request = new GraphQLRequest
		{
			Query = query.Build()
		};
		GraphQLResponse<GetPostsResponse> result = await _graphQLClient.SendQueryAsync<GetPostsResponse>(request);
		return result.Data.Posts;
	}
}
