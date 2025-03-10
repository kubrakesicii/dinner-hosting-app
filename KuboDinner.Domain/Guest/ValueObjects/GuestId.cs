using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; private set; }

        public GuestId(Guid value)
        {
            Value = value;
        }
        public static GuestId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
