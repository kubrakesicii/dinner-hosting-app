using KuboDinner.Domain.Common.SeedWork;

namespace KuboDinner.Domain.Menu.Events
{
    public record MenuCreated(Menu Menu) : IDomainEvent;
}
