using GraphQLTest.Context;
using GraphQLTest.GQL.Posts;
using GraphQLTest.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.GQL.Comments;

[ExtendObjectType(HotChocolate.Language.OperationType.Mutation)]
public class CommentMutations
{
	public async Task<Comment> AddCommentToPost(AppDbContext appDbContext, Guid postId, Guid authorId, string content)
	{
		var postExists = await appDbContext.Posts.AnyAsync(p => p.Id == postId);
		if(!postExists)
		{
			throw new Exception($"Post with id {postId} was not found");
		}
		var comment = new Comment
		{
			PostId = postId,
			AuthorId = authorId,
			Content = content
		};

		appDbContext.Comments.Add(comment);
		await appDbContext.SaveChangesAsync();

		return comment;
	}
}