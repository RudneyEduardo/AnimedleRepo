using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace animedle.Models;

public class Anime
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string AnimeName { get; set; } = null!;

    [BsonElement("status")]
    public string Status { get; set; } = null!;

    [BsonElement("season")]
    public string Season { get; set; } = null!;

    [BsonElement("releaseDate")]
    public string ReleaseDate { get; set; } = null!;

    [BsonElement("score")]
    public double Score { get; set; }

    [BsonElement("genres")]
    public required List<string> Genres { get; set; }

    [BsonElement("producers")]
    public required List<string> Producers { get; set; }

    [BsonElement("studios")]
    public required List<string> Studios { get; set; }
}