namespace KuboDinner.Domain.SeedWork
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();
    }
}
