using Identity.Mappers.Dto;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service
{
    public interface IUserCreateEventHandler
    {
        Task<IdentityResult> Handle(UserCreateCommand notification, CancellationToken cancellationToken);


    }
}
