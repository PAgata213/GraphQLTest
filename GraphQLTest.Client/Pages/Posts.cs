using GraphQLTest.Client.GQL;

namespace GraphQLTest.Client.Pages;

public partial class Posts(IPostsGQLService _postsService)
{
	protected readonly IPostsGQLService _postsService = _postsService;
}
