using Store.Infrastructure.Persistences.Context;
using Store.Infrastructure.Persistences.Repository;

namespace Store.Infrastructure.Persistences.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoregameContext _context;
    public IGameRepository Game { get; private set; }

    public UnitOfWork(StoregameContext context, IGameRepository game)
    {
        _context = context;
        Game = new GameRepository(_context);
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
