namespace Bookify.Infrastructre.Database;
internal sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema(Schemas.Application);

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Apartment> Apartments { get; set; }

}
