using AccountMapper.Dto;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Account.Command.Service.Handlers
{
    public interface IAccountCommandService
    {
        /// <summary>
        /// Actualizacion de un campo de la cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoDocument"></param>
        /// <returns></returns>
        Task<DtoRespuesta> UpdateClient(int id, JsonPatchDocument dtoDocument);
        /// <summary>
        /// Eliminacion de la cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DtoRespuesta> DeleteAccount(int id);
    }
}
