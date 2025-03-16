using KuboDinner.Domain.Common.SeedWork;

namespace KuboDinner.Domain.Bill.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public Price(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Currency, Amount };
        }
    }
}
