using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace GraphQLTest.Shared.Models;

public record Post
{
	[JsonProperty("id")]
	public Guid Id { get; } = Guid.CreateVersion7();

	[JsonProperty("creationDateTime")]
	public DateTime CreationDateTime { get; } = DateTime.UtcNow;

	[JsonProperty("title")]
	public string Title { get; set; } = default!;

	[JsonProperty("content")]
	public string Content { get; set; } = default!;

	[JsonProperty("comments")]
	public ICollection<Comment> Comments { get; set; } = [];

	[JsonProperty("authorId")]
	public Guid AuthorId { get; init; }
}
