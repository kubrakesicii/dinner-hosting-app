using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Dinner.ValueObjects
{
    public class Location : ValueObject
    {
        public Location(string name, string address, float latitude, float longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Name, Address, Latitude, Longitude };
        }
    }
}
