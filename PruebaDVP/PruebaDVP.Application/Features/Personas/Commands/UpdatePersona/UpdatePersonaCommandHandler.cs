using AutoMapper;
using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Personas;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Personas.Commands.UpdatePersona
{
    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Persona, bool>> expression = p => p.Identificador == request.Id;
            var includes = new List<Expression<Func<Persona, object>>>();
            includes.Add(p => p.Usuario!);
            var personaEntityToUpdate = await _unitOfWork.Repository<Persona>().GetByWithSpec(expression, includes);

            if (personaEntityToUpdate == null)
            {
                throw new NotFoundException(nameof(personaEntityToUpdate), request.Id);
            }

            _mapper.Map(request, personaEntityToUpdate, typeof(UpdatePersonaCommand), typeof(Persona));
            var result = await _unitOfWork.Repository<Persona>().UpdateAsync(personaEntityToUpdate);
            await _unitOfWork.Complete();

            return personaEntityToUpdate.Identificador!;
        }
    }
}
