using GraphQLTest.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLTest.Context.EntityConfiguration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasMany(x => x.Comments).WithOne(x => x.Post);

		builder.HasIndex(x => x.Id);
	}
}
