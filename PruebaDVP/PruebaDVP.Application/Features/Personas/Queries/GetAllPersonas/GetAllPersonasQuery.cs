using MediatR;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;

namespace PruebaDVP.Application.Features.Personas.Queries.GetAllPersonas
{
    public class GetAllPersonasQuery : IRequest<List<PersonaResponseQuery>>
    {
    }
}
