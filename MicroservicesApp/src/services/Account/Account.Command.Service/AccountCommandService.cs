using Account.Query.Service;
using AccountMapper;
using AccountMapper.Dto;
using AccountPersistenceDatabase.Repositories;
using Client.Mapper.Dto;
using Common.Repository.Generics;

namespace Account.Command.Service
{
    public class AccountCommandService : IAccountCommandService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountQueryService _accountQueryService;

        public AccountCommandService(IAccountRepository accountRepository, IAccountQueryService accountQueryService)
        {
            _accountRepository = accountRepository;
            _accountQueryService = accountQueryService;
        }
        /// <summary>
        /// Crear cuenta
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<DtoRespuesta> CreateAccount(AccountDto dto)
        {
            var newAccount = AccountMapper.AccountMapper.MapDtoToEntity(dto);
            _accountRepository.Create(newAccount);
            _accountRepository.Save();
            return Respuesta.DevolverRespuesta("Cuenta", "creado");
        }
        /// <summary>
        /// Eliminar cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DtoRespuesta> DeleteAccount(int id)
        {
            var accountFound = _accountQueryService.GetAccountEntity(id);
            _accountRepository.Delete(accountFound);
            _accountRepository.Save();
            return Respuesta.DevolverRespuesta("Cuenta", "creado");
        }
        /// <summary>
        /// Actualizar cuenta
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<DtoRespuesta> UpdateAccount(AccountDto dto)
        {
            var accountFound = _accountQueryService.GetAccountEntity(dto.CuentaId);
            AccountMapper.AccountMapper.MapDtoToEntity(accountFound, dto);
            _accountRepository.Update(accountFound);
            _accountRepository.Save();
            return Respuesta.DevolverRespuesta("Cuenta", "modificada");
        }

        public Task<DtoRespuesta> UpdateClient(int id, AccountDto dto)
        {
            throw new NotImplementedException();
        }
    }
}