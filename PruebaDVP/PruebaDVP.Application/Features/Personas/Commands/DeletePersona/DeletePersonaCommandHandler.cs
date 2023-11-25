using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Personas;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Personas.Commands.DeletePersona
{
    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Persona, bool>> expression = p => p.Identificador == request.Identificador!;
            var includes = new List<Expression<Func<Persona, object>>>();
            includes.Add(p => p.Usuario!);
            var PersonaEntity = await _unitOfWork.Repository<Persona>().GetByWithSpec(expression, includes);

            if (PersonaEntity == null)
            {
                throw new NotFoundException(nameof(PersonaEntity), request.Identificador!);
            }

            await _unitOfWork.Repository<Persona>().DeleteAsync(PersonaEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se puede eliminar el registro de tipo Persona con el identificador {request.Identificador}.");
            }

            return request.Identificador!;
        }
    }
}
