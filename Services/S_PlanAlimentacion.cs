using LifeArmony_api.Interfaces;
using LifeArmony_api.Models;
using MongoDB.Driver;
using System.Diagnostics;

namespace LifeArmony_api.Services
{
    public class S_PlanAlimentacion : IPlanAlimentacion
    {
        private IMongoCollection<PlanAlimentacion> _planAlimentacionCollection;
        public S_PlanAlimentacion()
        {
            var mongoClient = new MongoClient(ConfigMongoDB.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(ConfigMongoDB.DatabaseName);
            _planAlimentacionCollection = mongoDatabase.GetCollection<PlanAlimentacion>("PlanAlimentacion");
        }
        public async Task<int> InsertOne(PlanAlimentacion value)
        {
            int response = 0;
            try
            {
                await _planAlimentacionCollection.InsertOneAsync(value);
                response = 1;
            }
            catch (Exception ex)
            {
                response = 2;
            }
            return response;
        }

        public async Task<List<PlanAlimentacion>> SelectMany()
        {
            List<PlanAlimentacion>? response = null;
            try
            {
                response = await _planAlimentacionCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                response = null;
            }
            return response;

        }

        public async Task<PlanAlimentacion> SelectOne(string id)
        {

            PlanAlimentacion? response = null;
            try
            {
                response = await _planAlimentacionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public async Task<int> UpdateOne(string id, PlanAlimentacion value)
        {
            int response = 0;
            try
            {
                await _planAlimentacionCollection.ReplaceOneAsync(x => x.Id == id, value);
                response = 1;
            }
            catch (Exception ex)
            {
                response = 2;
            }
            return response;
        }

        public async Task<int> DeleteOne(string id)
        {

            int response = 0;
            try
            {
                await _planAlimentacionCollection.DeleteOneAsync(x => x.Id == id && x.status == 1);
                response = 1;
            }
            catch (Exception ex)
            {
                response = 2;
            }
            return response;

        }

    }
}
