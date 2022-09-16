using Identity.Domain;
using Identity.Mappers.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service
{
    public class UserCreateEventHandler : IUserCreateEventHandler, IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserCreateEventHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<IdentityResult> Handle(UserCreateCommand notification, CancellationToken cancellationToken)
        {
            var entry = new ApplicationUser
            {
                FirstName = notification.FirstName,
                LastName = notification.LastName,
                Email = notification.Email,
                UserName = notification.Email
            };
            return _userManager.CreateAsync(entry, notification.Password);
        }
    }
}