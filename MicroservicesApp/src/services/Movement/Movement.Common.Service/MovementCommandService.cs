using Common.Repository.Generics;
using Microsoft.AspNetCore.JsonPatch;
using Movement.Mapper;
using Movement.Mapper.Dto;
using Movement.PersistenceDatabase;
using mov = MovementDomain;

namespace Movement.Command.Service
{
    public class MovementCommandService : IMovementCommandService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementCommandService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }
        public Task<DtoRespuesta> CreateMovement(MovementDto dto)
        {
            var newMovement = MovementMapper.MapDtoToEntity(dto);
            _movementRepository.Create(newMovement);
            _movementRepository.Save();
            return Respuesta.DevolverRespuesta("Movimiento", "creado");
        }

        public Task<DtoRespuesta> UpdateMovement(MovementDto dto)
        {
            var movement = _movementRepository.GetById<mov.Movement>(dto.MovimientoId);
            var clientModified = MovementMapper.MapDtoToEntity(movement, dto);
            _movementRepository.Update(clientModified);
            _movementRepository.Save();
            return Respuesta.DevolverRespuesta("Cliente", "modificado");
        }

        public Task<DtoRespuesta> UpdateMovement(int id, JsonPatchDocument dtoDocument)
        {
            throw new NotImplementedException();
        }

        public Task<DtoRespuesta> DeleteteMovement(int id)
        {
            var clientFound = GetClient(id);
            _movementRepository.Delete(clientFound);
            return Respuesta.DevolverRespuesta("Movimiento", "eliminado");
        }

        public MovementDto GetClient(int id)
        {
            var movement = _movementRepository.GetById<mov.Movement>(id);
            var movementDto = MovementMapper.MapEntityToDto(movement);
            return movementDto;
        }
    }
}