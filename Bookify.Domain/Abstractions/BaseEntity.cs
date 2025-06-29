namespace Bookify.Domain.Abstractions;
public abstract class BaseEntity
{
    private readonly List<IDomainEvents> _domainEvents = new();

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }


    public IReadOnlyList<IDomainEvents> GetDomainEvents()
    {
        return _domainEvents.ToList();

    } 

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }


    public void RaiseDomainEvent(IDomainEvents domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }


   
}
