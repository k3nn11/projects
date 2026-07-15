using FoRavers.Helpers.DTOs;
using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Services
{
    public class UserService
    {
        private readonly IRepository<User> _users;
        private readonly IFollowRepository _follows;
        private readonly IRepository<RSVP> _rsvps;

        public UserService(IRepository<User> users, 
            IFollowRepository follows, 
            IRepository<RSVP> rsvps)
        {
            _users = users;
            _follows = follows;
            _rsvps = rsvps;

        }

        public async Task<Follow> FollowAsync(Guid userId, Guid targetId, string target)
        {
            var alreadyFollowing = await _follows
                .ExistsAsync(userId, targetId,target);
            if(alreadyFollowing)
            {
                throw new InvalidOperationException($"User with ID {userId} is already following {target} with ID {targetId}.");
            }
            var parsedTarget = Enum.TryParse<Target>(target, true, out var parsed) ? parsed : throw new ArgumentException($"Invalid target: {target}");

            var user = await _users.GetByIdAsync(userId);
            if (user is null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            var follow = new Follow(userId);
            follow.SetTarget(parsed, targetId);

            await _follows.AddAsync(follow);
            return follow;
        }

        public async Task<RSVP> MarkGoing(Guid userId, Guid eventId, RSVPStatus status)
        {
            var user = await _users.GetByIdAsync(userId);
            if (user is null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }
            var rsvp = new RSVP
            {
                UserId = userId,
                EventId = eventId,
                Status = status,
            };
            await _rsvps.AddAsync(rsvp);
            return rsvp;
        }

        public async Task UpdateProfileAsync(Guid userID, UpdateUserProfileDTO updateUserProfileDTO)
        {
            var user = await _users.GetByIdAsync(userID);
            if (user is null)
            {
                throw new InvalidOperationException($"User with ID {userID} not found.");
            }

            user.UpdateProfile(updateUserProfileDTO.UserName, updateUserProfileDTO.Email,
                updateUserProfileDTO.ProfilePhoto, updateUserProfileDTO.MusicGenre);

            _users.Update(user);
        }
    }
}
