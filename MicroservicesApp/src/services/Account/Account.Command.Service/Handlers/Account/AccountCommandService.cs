using Account.Query.Service.Account;
using AccountMapper.Dto;
using AccountPersistenceDatabase.Repositories;
using Common.Repository.Generics;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Account.Command.Service.Handlers.Account
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

        public Task<DtoRespuesta> UpdateClient(int id, JsonPatchDocument dtoDocument)
        {
            var accountFound = _accountQueryService.GetAccountEntity(id);
            dtoDocument.ApplyTo(accountFound);
            _accountRepository.Save();
            return Respuesta.DevolverRespuesta("Cuenta", "modificada");
        }
    }
}