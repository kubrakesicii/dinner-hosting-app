using KuboDinner.Domain.Bill.ValueObjects;
using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.Guest.Entities;
using KuboDinner.Domain.Guest.ValueObjects;
using KuboDinner.Domain.MenuReview.ValueObjects;
using KuboDinner.Domain.UserAggregate.ValueObjects;

namespace KuboDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId, Guid>
    {
        public Guest(GuestId id, string firstName, string lastName, float averageRating, string profileImage, UserId userId) : base(id)
        {
            Id = GuestId.CreateUnique();
            FirstName = firstName;
            LastName = lastName;
            AverageRating = averageRating;
            ProfileImage = profileImage;
            UserId = userId;

            UpcomingDinnerIds = _upcomingDinnerIds.AsReadOnly().ToList();
            PastDinnerIds = _pastDinnerIds.AsReadOnly().ToList();
            PendingDinnerIds = _pendingDinnerIds.AsReadOnly().ToList();
            BillIds = _billIds.AsReadOnly().ToList();
            MenuReviewIds = _menuReviewIds.AsReadOnly().ToList();
            GuestRatings = _guestRatings.AsReadOnly().ToList();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public float AverageRating { get; private set; }
        public string ProfileImage { get; private set; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds { get; private set; }
        public IReadOnlyList<DinnerId> PastDinnerIds { get; private set; }
        public IReadOnlyList<DinnerId> PendingDinnerIds { get; private set; }
        public IReadOnlyList<BillId> BillIds { get; private set; }
        public IReadOnlyList<MenuReviewId> MenuReviewIds { get; private set; }
        public IReadOnlyList<GuestRating> GuestRatings { get; private set; }

        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<GuestRating> _guestRatings = new();

        public UserId UserId { get; private set; }

    }
}
