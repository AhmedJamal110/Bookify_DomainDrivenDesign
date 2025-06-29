namespace Bookify.Domain.Users;
public interface IUserRepository
{
    Task<User?> GetByIDAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(User user, CancellationToken cancellationToken = default);
 
}
