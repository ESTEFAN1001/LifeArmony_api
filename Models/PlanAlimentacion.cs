using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LifeArmony_api.Models
{
    public class PlanAlimentacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        public string? nombre { get; set; }
        public string? recomendacion { get; set; }
        public List<string>? alimentos{ get; set; }
        public List<string>? restricciones { get; set; }
        public int status { get; set; }
    }
}
