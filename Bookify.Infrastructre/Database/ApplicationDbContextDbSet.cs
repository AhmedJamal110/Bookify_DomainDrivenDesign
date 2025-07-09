namespace Bookify.Infrastructre.Database;
public partial class ApplicationDbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<User> Users { get; set; }


}
