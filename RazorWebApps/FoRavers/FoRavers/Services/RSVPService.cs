using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Services
{
    public class RSVPService
    {
        private readonly IRepository<Event> _events;
        private readonly IRSVPRepository _rsvps;
        private readonly IRepository<User> _users;

        public RSVPService(IRepository<Event> events, IRSVPRepository rsvps, IRepository<User> users)
        {
            _events = events;
            _rsvps = rsvps;
            _users = users;
        }

        public async Task<RSVP> MarkGoing(Guid userId, Guid eventId)
        {
            var evt = await _events.GetByIdAsync(eventId);
            if(evt == null)
            {
                throw new ArgumentException("Event not found", nameof(eventId));
            }

            var existing = await _rsvps.GetUserAndEventAsync(userId, eventId);
            if(existing is not null)
            {
                if(existing.Status == RSVPStatus.Confirmed)
                {
                    return existing;
                }
                existing.Status = RSVPStatus.Confirmed;
                evt.IncrementCount();
                _events.Update(evt);
                _rsvps.Update(existing);
                return existing;
            }

            RSVP rsvp = new(userId, eventId);
            rsvp.Confirm();
            evt.IncrementCount();
            _rsvps.Update(rsvp);
            _events.Update(evt);

            return rsvp;
        }

        public async Task CancelAsync(Guid userId, Guid eventId)
        {
            var evt = await _events.GetByIdAsync(eventId);
            if(evt == null)
            {
                throw new ArgumentException("Event not found", nameof(eventId));
            }

            var existing = await _rsvps.GetUserAndEventAsync(userId, eventId);
            if (existing is null || existing.Status != RSVPStatus.Confirmed)
            {
                return;
            }

            existing.Cancel();
            evt.DecrementCount();
            _rsvps.Update(existing);
            _events.Update(evt);
        }
    }
}
