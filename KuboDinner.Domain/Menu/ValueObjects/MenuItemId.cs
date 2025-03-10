﻿using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }

        public MenuItemId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}
