using System.Linq;

namespace KuboDinner.Domain.Common.SeedWork
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType()) return false;

            var valObj = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valObj.GetEqualityComponents());
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }


        // override equality methods of obj type
    }
}
