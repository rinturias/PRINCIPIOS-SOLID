
using Microsoft.Extensions.DependencyInjection;
using Puchage.Technical.Evaluation.Application.Interfaces;
using Puchage.Technical.Evaluation.Application.Services;

using Puchage.Technical.Evaluation.infrastructure.Context;

using System;
using System.Security.Cryptography;
using Usuarios.Technical.Evaluation.Application.encryption;
using Usuarios.Technical.Evaluation.Domain.Interfaces.Repositories;
using Usuarios.Technical.Evaluation.infrastructure.Context;
using Usuarios.Technical.Evaluation.infrastructure.Repositories;

namespace Puchage.Technical.Evaluation.IoC
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
           services.AddScoped<IContextDatabase, ContextDatabase> ();
           services.AddScoped<IUsuariosRepository, UsuarioRepository>();
            services.AddScoped<ILoginService, UsuarioService>();
            services.AddScoped<IEncryption, Usuarios.Technical.Evaluation.Application.encryption.SHA1>();
            


        }
    }
}
