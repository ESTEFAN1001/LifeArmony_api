using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LifeArmony_api.Models
{
    public class AlimentosPermitidos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        public string? nombre { get; set; }
        public string? categoria { get; set; }
    }
}
