using MediatR;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;

namespace PruebaDVP.Application.Features.Personas.Queries.GetPersonaById
{
    public class GetPersonaByIdQuery : IRequest<PersonaResponseQuery>
    {
        public string? Identificador { get; set; }

        public GetPersonaByIdQuery(string identificador)
        {
            if (identificador == null)
            {
                throw new ArgumentNullException(nameof(identificador));
            }
            Identificador = identificador;
        }
    }
}
