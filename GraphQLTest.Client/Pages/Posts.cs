using GraphQLTest.Client.GraphQL;

namespace GraphQLTest.Client.Pages;

public partial class Posts(IPostsGQLService _postsService)
{
	protected readonly IPostsGQLService _postsService = _postsService;
}
