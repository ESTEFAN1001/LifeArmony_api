namespace LifeArmony_api.Interfaces.ICrud
{
    public interface ISelectOne<T>
    {
        public Task<T> SelectOne(string id);
    }
}
