using AccountMapper.Dto;
using Client.Mapper.Dto;

namespace Account.Command.Service
{
    public interface IAccountCommandService
    {
        Task<DtoRespuesta> CreateAccount(AccountDto dto);
        Task<DtoRespuesta> UpdateAccount(AccountDto dto);
        Task<DtoRespuesta> UpdateClient(int id, AccountDto dto);
        Task<DtoRespuesta> DeleteAccount(int id);
    }
}
