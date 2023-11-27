using AutoMapper;
using MediatR;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Domain.Personas;

namespace PruebaDVP.Application.Features.Personas.Queries.GetAllPersonas
{
    public class GetAllPersonasQueryHandler : IRequestHandler<GetAllPersonasQuery, List<PersonaResponseQuery>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPersonasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PersonaResponseQuery>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
        {

            var personas = await _unitOfWork.Repository<Persona>().GetAll();
            return _mapper.Map<List<PersonaResponseQuery>>(personas);
        }
    }
}
