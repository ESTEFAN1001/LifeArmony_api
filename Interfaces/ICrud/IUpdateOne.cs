namespace LifeArmony_api.Interfaces.ICrud
{
    public interface IUpdateOne<T>
    {
        public Task<int> UpdateOne(string id,T value);
    }
}
