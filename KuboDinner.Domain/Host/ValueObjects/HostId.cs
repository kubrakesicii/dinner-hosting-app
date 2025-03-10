using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; private set; }

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
