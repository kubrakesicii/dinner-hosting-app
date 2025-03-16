﻿using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Bill.ValueObjects
{
    public sealed class BillId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
