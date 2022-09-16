using Identity.Mappers.Request;
using MediatR;

using System.ComponentModel.DataAnnotations;

namespace Identity.Mappers.Dto
{
    public class UserLoginCommand : IRequest<IdentityAccess>
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
