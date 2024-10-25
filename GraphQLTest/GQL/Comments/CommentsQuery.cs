using GraphQLTest.Context;
using GraphQLTest.Shared.Models;

namespace GraphQLTest.GQL.Comments;

[ExtendObjectType(HotChocolate.Language.OperationType.Query)]
public class CommentsQuery
{
	//[UsePaging]
	[UseProjection]
	[UseFiltering]
	[UseSorting]
	public IQueryable<Comment> GetComments(AppDbContext dbContext) => dbContext.Comments;
}
