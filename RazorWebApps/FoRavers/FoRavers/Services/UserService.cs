using FoRavers.Helpers.DTOs;
using FoRavers.Models;
using FoRavers.Repositories;

namespace FoRavers.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Follow> _followRepository;
        private readonly IRepository<RSVP> _rsvpRepository;

        public UserService(IRepository<User> userRepository, 
            IRepository<Follow> followRepository, 
            IRepository<RSVP> rsvpRepository)
        {
            _userRepository = userRepository;
            _followRepository = followRepository;
            _rsvpRepository = rsvpRepository;

        }

        public async Task<Follow> FollowAsync(Guid userId, Guid targetId, Target target)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            var follow = new Follow
            {
                UserId = userId,
                TargetId = targetId,
                Target = target,
            };

            await _followRepository.AddAsync(follow);
            return follow;
        }

        public async Task<RSVP> MarkGoing(Guid userId, Guid eventId, RSVPStatus status)
        {
            var user = await _userRepository.GetByIdAsync(userId);
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
            await _rsvpRepository.AddAsync(rsvp);
            return rsvp;
        }

        public async Task UpdateProfileAsync(Guid userID, UpdateUserProfileDTO updateUserProfileDTO)
        {
            var user = await _userRepository.GetByIdAsync(userID);
            if (user is null)
            {
                throw new InvalidOperationException($"User with ID {userID} not found.");
            }

            user.UpdateProfile(updateUserProfileDTO.UserName, updateUserProfileDTO.Email,
                updateUserProfileDTO.ProfilePhoto, updateUserProfileDTO.MusicGenre);

            _userRepository.Update(user);
        }
    }
}
