
using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;
namespace GraphQLTest.Context;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
	public DbSet<Post> Posts { get; set; }
	public DbSet<Comment> Comments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(GraphQLTest.Context.AppDbContext).Assembly);
	}
}