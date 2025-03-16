namespace KuboDinner.Domain.SeedWork
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId> where TId : AggregateRootId<TIdType>
    {
        protected AggregateRoot() : base(default!) { } // Pass default value to Entity<TId>
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime UpdateDate { get; private set; } = DateTime.Now;
        protected AggregateRoot(TId id) : base(id)
        {
            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        public void UpdateAggregate() => UpdateDate = DateTime.Now;
    }
}
