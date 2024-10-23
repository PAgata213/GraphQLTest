using GraphQL.Query.Builder;

using GraphQLTest.Shared.Models;

namespace GraphQLTest.Client.GQL;

public interface IPostsGQLService
{
	Task<IList<Post>> GetPostsAsync(IQuery<Post>? query = null);
}