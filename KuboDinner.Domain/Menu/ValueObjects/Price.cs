using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    public class Price : ValueObject
    {
        private Price() { }
        public string Currency { get; }
        public decimal Amount { get; }

        public Price(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Currency, Amount };
        }
    }
}
