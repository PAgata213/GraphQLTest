namespace GraphQLTest.Models;

public record Post
{
	public Guid Id { get; } = Guid.CreateVersion7();
	public DateTime CreationDateTime { get; } = DateTime.UtcNow;
	public string Title { get; set; } = default!;
	public string Content { get; set; } = default!;
	public ICollection<Comment> Comments { get; init; } = [];
	public Guid AuthorId { get; init; }
}
