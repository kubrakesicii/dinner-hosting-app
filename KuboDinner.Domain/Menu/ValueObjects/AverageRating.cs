using KuboDinner.Domain.MenuAggregate.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    public class AverageRating : ValueObject
    {
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
