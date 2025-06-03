using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace animedle.Models;

public class Anime
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string AnimeName { get; set; } = null!;

    public string MainGenre { get; set; } = null!;

    public string SecondaryGenre { get; set; } = null!;

    public string Studio { get; set; } = null!;

    public int Rating { get; set; }
}