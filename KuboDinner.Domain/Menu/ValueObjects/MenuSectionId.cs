using KuboDinner.Domain.Common.SeedWork;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        private MenuSectionId() { }
        public Guid Value { get; private set; }

        public MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
