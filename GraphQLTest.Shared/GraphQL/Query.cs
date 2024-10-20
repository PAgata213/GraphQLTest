using GraphQL.Query.Builder;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.Shared.GraphQL;
public static class Query
{
	public static IQuery<Post> GetPosts
		=> new Query<Post>("posts")
			.AddField(q => q.Id)
			.AddField(q => q.AuthorId)
			.AddField(q => q.Title)
			.AddField(q => q.CreationDateTime)
			.AddField(q => q.Content)
			.AddField(q => q.Comments,
				sq => sq.AddField(c => c.Id)
					.AddField(c => c.AuthorId)
					.AddField(c => c.Content)
					.AddField(c => c.CreationDateTime));
}
