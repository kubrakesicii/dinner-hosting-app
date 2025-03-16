using KuboDinner.Domain.Guest.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuReview.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.MenuReview
{
    public class MenuReview : AggregateRoot<MenuReviewId, Guid>
    {
        private MenuReview() { }
        public MenuReview(MenuReviewId id,MenuId menuId, HostId hostId, GuestId guestId) : base(id)
        {
            MenuId = menuId;
            HostId = hostId;
            GuestId = guestId;
        }

        public MenuId MenuId { get; private set; }
        public HostId HostId { get; private set; }
        public GuestId GuestId { get; private set; }

        public static MenuReview Create(MenuId menuId, HostId hostId, GuestId guestId)
        {
            return new MenuReview(MenuReviewId.CreateUnique(),menuId, hostId, guestId);
        }
    }
}
