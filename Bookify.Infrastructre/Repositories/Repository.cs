namespace Bookify.Infrastructre.Repositories;
internal abstract class Repository<T>where T : BaseEntity
{

    protected readonly ApplicationDbContext _context;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIDAsync(Guid id , CancellationToken cancellationToken = default )
    {
        return await _context
            .Set<T>()
            . FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }


    public async Task AddAsync(T entity , CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }


}
