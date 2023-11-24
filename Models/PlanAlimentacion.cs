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
        public string? icon { get; set; }
        public string? tipo_diabetes { get; set; }
        public int? edad_min { get; set; }
        public int? edad_max { get; set; }
        public double? peso_min { get; set; }
        public double? peso_max { get; set; }
        public double? talla_min { get; set; }
        public double? talla_max { get; set; }
        public List<DietaSemanal> alimentos { get; set; }

        public PlanAlimentacion(string? nombre, string? recomendacion, string? tipo_diabetes, int? edad_min, int? edad_max, double? peso_min, double? peso_max, double? talla_min, double? talla_max, List<DietaSemanal> alimentos)
        {
            this.nombre = nombre;
            this.recomendacion = recomendacion;
            this.tipo_diabetes = tipo_diabetes;
            this.edad_min = edad_min;
            this.edad_max = edad_max;
            this.peso_min = peso_min;
            this.peso_max = peso_max;
            this.talla_min = talla_min;
            this.talla_max = talla_max;
            this.alimentos = alimentos;
        }
    }
}
