﻿using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Dinner.ValueObjects
{
    public sealed class DinnerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; private protected set; }

        public DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
