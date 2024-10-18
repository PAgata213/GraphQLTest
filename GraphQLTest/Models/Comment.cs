using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLTest.Models;

public record Comment
{
	public Guid Id { get; } = Guid.CreateVersion7();
	public DateTime CreationDateTime { get; } = DateTime.UtcNow;
	public string Content { get; set; } = default!;
	public Guid AuthorId { get; set; }

	[ForeignKey("PostId")]
	public Guid PostId { get; set; }
	public virtual Post Post { get; set; } = default!;
}