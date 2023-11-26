using AutoMapper;
using PruebaDVP.Application.Features.Personas.Commands.CreatePerson;
using PruebaDVP.Application.Features.Personas.Commands.UpdatePersona;
using PruebaDVP.Application.Features.Personas.Queries.Dtos;
using PruebaDVP.Application.Features.Usuarios.Commands.CreateUsuario;
using PruebaDVP.Application.Features.Usuarios.Commands.UpdateUsuario;
using PruebaDVP.Application.Features.Usuarios.Queries.Dtos;
using PruebaDVP.Domain.Personas;
using PruebaDVP.Domain.Usuarios;

namespace PruebaDVP.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaResponseQuery>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Identificador));

            CreateMap<UpdatePersonaCommand, Persona>()
                .ForMember(dest => dest.Identificador, opts => opts.MapFrom(src => src.Id));

            CreateMap<Usuario, UsuarioResponseQuery>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Identificador));

            CreateMap<UpdateUsuarioCommand, Usuario>()
                .ForMember(dest => dest.Identificador, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Pass, opts => opts.MapFrom(src => src.Password));
            CreateMap<CreateUsuarioCommand, Usuario>()
                .ForMember(dest => dest.Pass, opts => opts.MapFrom(src => src.Password));

            CreateMap<CreatePersonaCommand, Persona>();
            
        }
    }
}
