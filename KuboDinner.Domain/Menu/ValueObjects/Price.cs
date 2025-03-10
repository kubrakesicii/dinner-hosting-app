namespace KuboDinner.Domain.MenuAggregate.ValueObjects
{
    public record Price(string Currency, decimal Amount) : ValueObject;
}
