using KuboDinner.Domain.Common.SeedWork;

namespace KuboDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public HostId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
