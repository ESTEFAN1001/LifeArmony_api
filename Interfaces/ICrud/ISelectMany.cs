namespace LifeArmony_api.Interfaces.ICrud
{
    public interface ISelectMany<T>
    {
        public Task<List<T>> SelectMany();
    }
}
