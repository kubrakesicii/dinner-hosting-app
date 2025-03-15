using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        private MenuId() { }
        public Guid Value { get; }

        public MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
