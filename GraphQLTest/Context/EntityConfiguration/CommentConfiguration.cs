using GraphQLTest.Shared.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLTest.Context.EntityConfiguration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasIndex(x => x.Id);
	}
}
