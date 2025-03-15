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

        public int NumRatings { get; set; }
        public float Value { get; }

        //public static AverageRating CreateUnique()
        //{
        //    //return new(Guid.NewGuid());
        //}

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new {Value,NumRatings};
        }
    }
}
