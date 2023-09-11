namespace LifeArmony_api.Interfaces.ICrud
{
    public interface IInsertOne<T>
    {
        public Task<int> InsertOne(T value);
    }
}
