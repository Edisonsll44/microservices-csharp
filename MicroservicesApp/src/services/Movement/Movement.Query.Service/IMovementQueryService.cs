using Movement.Mapper.Dto;
using mov = Movement.Domain;

namespace Movement.Query.Service
{
    public interface IMovementQueryService
    {
        /// <summary>
        /// DEvuelve un movimiento filtrado por
        /// su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MovementDto GetMovemment(int id);
        /// <summary>
        /// DEvuelve todos los movimientos
        /// </summary>
        /// <returns></returns>
        IEnumerable<MovementDto> GetMovemments();
        /// <summary>
        /// DEvuelve un movimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        mov.Movement GetMovemmentEntity(int id);

        /// <summary>
        /// DEvuelve los movimientos filtrado por
        /// fecha, o nombre cliente o identificacion del
        /// client
        /// </summary>
        /// <param name="dateQuery"></param>
        /// <param name="clientName"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<IEnumerable<MovementDto>> GetMovementByDateOrClient(DateTime dateQuery, string clientName, string clientId);

    }
}
