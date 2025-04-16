using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ScoringTablet.Models
{
    public class ScoreEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int SelectedTable { get; set; } = 0;
        public string GameNumber { get; set; } = "";

        public TeamData Team1 { get; set; } = new();
        public TeamData Team2 { get; set; } = new();
    }

    public class TeamData
    {
        public string Name { get; set; } = "";
        public int Score { get; set; } = 0;
        public int OrangeBalls { get; set; } = 0;
        public int PurpleBalls { get; set; } = 0;
    }

    
}
