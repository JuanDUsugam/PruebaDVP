using AutoMapper;
using MediatR;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Domain.Personas;

namespace PruebaDVP.Application.Features.Personas.Commands.CreatePerson
{
    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePersonaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var personaEntity = _mapper.Map<Persona>(request);
            personaEntity.Identificador = Guid.NewGuid().ToString();

            await _unitOfWork.Repository<Persona>().CreateAsync(personaEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("No se puede insertar el registro de tipo Persona.");
            }

            return personaEntity.Identificador;
        }
    }
}
