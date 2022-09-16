using Identity.Mappers.Dto;
using Identity.Mappers.Request;

namespace Identity.Command.Service.Contracts
{
    public interface IUserLoginEventHandler
    {
        Task<IdentityAccess> Handle(UserLoginCommand notification, CancellationToken token);
    }
}
