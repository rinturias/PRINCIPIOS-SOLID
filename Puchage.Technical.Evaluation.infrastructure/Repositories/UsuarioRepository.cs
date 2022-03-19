using Microsoft.Extensions.Logging;
using Puchage.Technical.Evaluation.infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Domain.Interfaces.Repositories;
using Usuarios.Technical.Evaluation.infrastructure.Context;

namespace Usuarios.Technical.Evaluation.infrastructure.Repositories
{
 public  class UsuarioRepository: IUsuariosRepository
    {
        private readonly IContextDatabase _context;
        private readonly ILogger<UsuarioRepository> _logger;
        public UsuarioRepository(IContextDatabase contextDatabase, ILogger<UsuarioRepository> logger)
        {
            this._context = contextDatabase;
            _logger = logger;
        }

        public Task<bool> LoginUsuarios(Domain.Entitites.Usuarios.User usuarios)
        {
            string namemethod = "R-LoginUsuarios";
            var usuario = _context._Usuario.Where(x => x.usuario.Contains(usuarios.usuario) && x.clave.Contains(usuarios.clave)).FirstOrDefault();

            if (usuario == null)
            {
                _logger.LogWarning(namemethod + " ,Usuario no encontrado: " + usuarios.usuario);
                return Task.FromResult(false);
            }
            else
            {
                _logger.LogWarning(namemethod + " ,Usuario encontrado: " + usuarios.usuario);
                return Task.FromResult(true);
            }

        }

  

        public  Task<bool> RegisterUsuarios(Domain.Entitites.Usuarios.User usuarios)
        {
            string namemethod = "R-RegisterUsuarios";
            _context._Usuario.Add(usuarios);
            var result=  _context.SaveChanges();
            _logger.LogWarning(namemethod + " ,Registro Correctamente el usuario: " + usuarios.usuario);
            return Task.FromResult(true);
        }
    }
}
