namespace Store.Infrastructure.Persistences.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoregameContext _context;
    public IGameRepository Game { get; }

    public UnitOfWork(StoregameContext context, IGameRepository game)
    {
        _context = context;
        Game = game;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChagens()
    {
        _context.SaveChanges();
    }

    public async Task SaveChagensAsync()
    {
        await _context.SaveChangesAsync();
    }
}
