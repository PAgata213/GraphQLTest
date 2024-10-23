using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace GraphQLTest.Shared.Models;

public record Comment
{
	[JsonProperty("id")]
	public Guid Id { get; } = Guid.CreateVersion7();

	[JsonProperty("creationDateTime")]
	public DateTime CreationDateTime { get; } = DateTime.UtcNow;

	[JsonProperty("content")]
	public string Content { get; set; } = default!;

	[JsonProperty("authorId")]
	public Guid AuthorId { get; set; }

	[ForeignKey("PostId")]
	public Guid PostId { get; set; }

	[JsonIgnore]
	public virtual Post Post { get; set; } = default!;
}