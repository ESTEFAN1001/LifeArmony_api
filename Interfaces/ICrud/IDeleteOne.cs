namespace LifeArmony_api.Interfaces.ICrud
{
    public interface IDeleteOne<T>
    {
        public Task<int> DeleteOne(string id);
    }
}
