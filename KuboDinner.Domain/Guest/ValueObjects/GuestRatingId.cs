﻿using KuboDinner.Domain.Common.SeedWork;

namespace KuboDinner.Domain.Guest.ValueObjects
{
    public sealed class GuestRatingId : ValueObject
    {
        public Guid Value { get; private set; }

        public GuestRatingId(Guid value)
        {
            Value = value;
        }
        public static GuestRatingId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
