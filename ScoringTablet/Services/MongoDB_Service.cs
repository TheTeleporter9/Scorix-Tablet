using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using ScoringTablet.Models;

namespace ScoringTablet.Services
{
    public class MongoDB_Service<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDB_Service(IOptions<MongoDBSettings> settings, string collectionName)
        {
        var mongoClient = new MongoClient("mongodb+srv://TheTeleporter9:JTMdX9HFCllYRJDX@wro-scoring.n0khn.mongodb.net/?retryWrites=true&w=majority&appName=WRO-scoring");
        var mongoDatabase = mongoClient.GetDatabase("Wro-scoring");
        _collection = mongoDatabase.GetCollection<T>(collectionName);

        Console.WriteLine("Connection String: " + settings.Value.ConnectionString);

        try
        {
            var result = mongoDatabase.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Pinged MongoDB successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("MongoDB connection failed: " + ex.Message);
        }
    }   

        public async Task InsertOneAsync(T document) =>
            await _collection.InsertOneAsync(document);

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();
    }
}
