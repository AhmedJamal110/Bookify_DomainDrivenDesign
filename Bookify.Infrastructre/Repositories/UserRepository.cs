namespace Bookify.Infrastructre.Repositories;
internal sealed class UserRepository : Repository<User> , IUserRepository
{
    public UserRepository(ApplicationDbContext _context) 
        : base(_context)
    {
    }

   
    
}
