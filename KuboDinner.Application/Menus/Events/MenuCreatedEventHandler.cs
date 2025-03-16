using KuboDinner.Domain.Menu.Events;
using MediatR;

namespace KuboDinner.Application.Menus.Events
{
    public class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
