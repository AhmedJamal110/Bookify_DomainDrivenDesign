using System.Reflection;
using Bookify.Application.Exceptions;
using Bookify.Infrastructre.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookify.Infrastructre.Database;
public partial class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IPublisher _publisher) : DbContext(options) , IUnitOfWork
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyDeciamalConfiguration();
        modelBuilder.ApplyRestrictRelationConfigration();

        base.OnModelCreating(modelBuilder);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        try
        {

            using IDbContextTransaction transaction = await Database.BeginTransactionAsync(cancellationToken);

            int result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEvents();

            await transaction.CommitAsync(cancellationToken);



            return result;

        }
        catch (ConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency error occurred while saving changes.", ex);
        }

    }

   
    private async Task PublishDomainEvents()
    {
        List<IDomainEvents> domainEvents = ChangeTracker
            .Entries<BaseEntity>()
            .Select(Entry => Entry.Entity)
            .SelectMany(entity =>
            {
                IReadOnlyList<IDomainEvents> domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var item in domainEvents)
        {
            await _publisher.Publish(item); 
        }

    }

}
