using AutoMapper;
using FluentValidation.Internal;
using MediatR;
using PruebaDVP.Application.Exceptions;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Specifications;
using PruebaDVP.Domain.Personas;
using System.Linq.Expressions;

namespace PruebaDVP.Application.Features.Personas.Queries.GetPersonaById
{
    public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, PersonaResponseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonaByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonaResponseQuery> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Persona, bool>> expression = p => p.Identificador == request.Identificador;
            var includes = new List<Expression<Func<Persona, object>>>();
            includes.Add(p => p.Usuario!);
            var personaEntity = await _unitOfWork.Repository<Persona>().GetByWithSpec(expression, includes);

            if (personaEntity == null)
            {
                throw new NotFoundException(nameof(personaEntity), request.Identificador);
            }

            return _mapper.Map<PersonaResponseQuery>(personaEntity);
        }
    }
}
