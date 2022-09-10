using Microsoft.AspNetCore.JsonPatch;
using Movement.Mapper.Dto;

namespace Movement.Command.Service
{
    public interface IMovementCommandService
    {
        /// <summary>
        /// Crearcuenta movimiento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DtoRespuesta> CreateMovement(MovementDto dto);
        /// <summary>
        /// Actualiza un movimiento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<DtoRespuesta> UpdateMovement(MovementDto dto);
        /// <summary>
        /// Actualizacion de un campo del movimiento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoDocument"></param>
        /// <returns></returns>
        Task<DtoRespuesta> UpdateMovement(int id, JsonPatchDocument dtoDocument);
        /// <summary>
        /// Eliminacion del movimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        Task<DtoRespuesta> DeleteteMovement(int id);
    }
}
