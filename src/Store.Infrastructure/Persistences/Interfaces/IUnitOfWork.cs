namespace Store.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Game { get; }
        void SaveChagens();
        Task SaveChagensAsync();
    }
}
