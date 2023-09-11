namespace LifeArmony_api.Models
{
    public class ConfigMongoDB
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
    }
}
