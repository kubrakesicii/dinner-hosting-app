using KuboDinner.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    [Owned]
    public sealed class AverageRating : ValueObject
    {
        private AverageRating() { }
        public AverageRating(int numRatings, float value)
        {
            NumRatings = numRatings;
            Value = value;
        }

        public int NumRatings { get; private set; }
        public float Value { get; private set;}

        public static AverageRating CreateNew()
        {
            return new(0,0);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new {Value,NumRatings};
        }
    }
}
