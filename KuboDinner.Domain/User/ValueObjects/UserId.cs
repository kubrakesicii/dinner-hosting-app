using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static UserId CreateUnique()
        {
            return new (Guid.NewGuid());
        }
    }
}
