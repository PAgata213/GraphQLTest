using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Query.Builder;

using GraphQLTest.Client.Pages;
using GraphQLTest.Shared.GQL.Response;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.Client.GQL;

public class PostsGQLService(IGraphQLClient _graphQLClient) : IPostsGQLService
{
	private readonly IGraphQLClient _graphQLClient = _graphQLClient;

	public async Task<IList<Post>> GetPostsAsync(IQuery<Post>? query = null)
	{
		query ??= GraphQLTest.Shared.GQL.Query.GetPosts;
		var request = new GraphQLRequest
		{
			Query = $"{{ {query.Build()} }}",
		};

		GraphQLResponse<GetPostsResponse> result = await _graphQLClient.SendQueryAsync<GetPostsResponse>(request);
		return result.Data.Posts;
	}
}
