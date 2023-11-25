using PruebaDVP.Domain.Personas;
using PruebaDVP.Domain.Usuarios;
using PruebaDVP.Infra.Persistence.SQLSever.Context;

namespace PruebaDVP.Infra.Persistence.SQLSever.Settings
{
    public class LoadDataBase
    {
        public static async Task InsertData(AppDbContext context)
        {
            var usuario = new Usuario();
            if (!context.Usuarios.Any())
            {
                usuario.Identificador = Guid.NewGuid().ToString();
                usuario.NombreUsuario = "admin@admin";
                usuario.Pass = "Pass123$";
                usuario.FechaCreacion = DateTime.Now;
                await context.Usuarios.AddAsync(usuario);
                await context.SaveChangesAsync();
            }
            if(!context.Personas.Any())
            {
                await context.Personas.AddAsync(new Persona
                {
                    Identificador = Guid.NewGuid().ToString(),
                    Nombres = "Administrador",
                    Apellidos = "Administrador",
                    TipoIdentificacion = "cc",
                    NumeroIdentificacion = 1111111,
                    Email = "admin@admin.com",
                    FechaCreacion = DateTime.Now,
                    UsuarioId = usuario.Identificador
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
